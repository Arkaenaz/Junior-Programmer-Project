using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private InputAction _moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveInput = InputSystem.actions.FindAction("Move");
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = _moveInput.ReadValue<Vector2>().x;
        transform.Rotate(Vector3.up, horizontalInput * _rotationSpeed * Time.deltaTime);
    }
}
