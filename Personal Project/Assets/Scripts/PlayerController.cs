using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rangeX = 10f;
    private Rigidbody _playerRb;

    private InputAction _moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -_rangeX || transform.position.x > _rangeX)
        {
            float x = Mathf.Clamp(transform.position.x, -_rangeX, _rangeX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            _playerRb.linearVelocity = new Vector3(0, _playerRb.linearVelocity.y, _playerRb.linearVelocity.z); // Reset horizontal velocity
        }
        float horizontalInput = _moveInput.ReadValue<Vector2>().x;
        float verticalInput = _moveInput.ReadValue<Vector2>().y;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        _playerRb.AddForce(movement * _moveSpeed);
    }
}
