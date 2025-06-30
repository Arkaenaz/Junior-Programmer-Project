using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 20.0f;
    [SerializeField] private float _turnSpeed = 45.0f;

    private float _horizontalInput;
    private float _forwardInput;

    private InputAction _moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = _moveAction.ReadValue<Vector2>().x;
        _forwardInput = _moveAction.ReadValue<Vector2>().y;

        // Move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        // Rotates the vehicle based on horizontal input
        transform.Rotate(Vector3.up, _turnSpeed * _horizontalInput * Time.deltaTime);
    }
}
