using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitController : MonoBehaviour
{
    [SerializeField] protected float _maxSpeed = 5f;
    [SerializeField] protected float _moveSpeed = 5f;
    [SerializeField] private float _outOfBoundsRangeX = 10f;
    [SerializeField] private float _outOfBoundsRangeY = -10f;

    protected Rigidbody _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ConstrainPosition();
        TriggerOutOfBounds();
    }

    void TriggerOutOfBounds()
    {
        if (transform.position.y < _outOfBoundsRangeY)
        {
            OutOfBoundsHandler();
        }
    }

    protected virtual void Move() { }
    protected virtual void ConstrainPosition()
    {
        if (transform.position.x < -_outOfBoundsRangeX || transform.position.x > _outOfBoundsRangeX)
        {
            float x = Mathf.Clamp(transform.position.x, -_outOfBoundsRangeX, _outOfBoundsRangeX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            _rigidbody.linearVelocity = new Vector3(0, _rigidbody.linearVelocity.y, _rigidbody.linearVelocity.z); // Reset horizontal velocity
        }
    }

    protected virtual void OutOfBoundsHandler() {}
}
