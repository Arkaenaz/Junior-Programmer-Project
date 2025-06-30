using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _rangeX = 10.0f;
    [SerializeField] private GameObject _projectilePrefab;
    private float _horizontalInput;

    private InputAction _moveAction;
    private InputAction _spaceAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _spaceAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -_rangeX || transform.position.x > _rangeX)
        {
            float x = Mathf.Clamp(transform.position.x, -_rangeX, _rangeX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        if (_spaceAction.triggered)
        {
            // Launch a projectile from the player
            Instantiate(_projectilePrefab, transform.position, _projectilePrefab.transform.rotation);
        }

        // Grab input
        _horizontalInput = _moveAction.ReadValue<Vector2>().x;

        // Move player
        transform.Translate(Vector3.right * _horizontalInput * _speed * Time.deltaTime);
    }
}
