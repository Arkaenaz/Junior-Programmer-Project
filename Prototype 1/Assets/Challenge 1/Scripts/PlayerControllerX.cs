using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    private float _verticalInput;

    private InputAction _moveAction;
    // Start is called before the first frame update
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        _verticalInput = _moveAction.ReadValue<Vector2>().y;

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * _rotationSpeed * _verticalInput * Time.deltaTime);
    }
}
