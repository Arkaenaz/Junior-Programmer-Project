using UnityEngine;
using UnityEngine.InputSystem;

// INHERITANCE
public class PlayerController : UnitController
{
    [SerializeField] private MainManager _mainManager;

    private InputAction _moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveInput = InputSystem.actions.FindAction("Move");

        _rigidbody.maxLinearVelocity = _maxSpeed;
    }

    // POLYMORPHISM
    protected override void Move()
    {
        float horizontalInput = _moveInput.ReadValue<Vector2>().x;
        float verticalInput = _moveInput.ReadValue<Vector2>().y;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        _rigidbody.AddForce(movement * _moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }

    // POLYMORPHISM
    protected override void OutOfBoundsHandler()
    {
        Debug.Log("Player out of bounds, destroying player.");
        Debug.Log("Game Over!");
        _mainManager.GameOver();
    }
}
