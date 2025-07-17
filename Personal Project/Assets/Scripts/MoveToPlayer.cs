using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;

    private GameObject _player;
    private Rigidbody _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _rb.maxLinearVelocity = _maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
            return;

        Vector3 direction = _player.transform.position - transform.position;
        _rb.AddForce(direction * Time.deltaTime, ForceMode.VelocityChange);
    }
}
