using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCameraX : MonoBehaviour
{
    private float speed = 200;
    public GameObject player;

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
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
