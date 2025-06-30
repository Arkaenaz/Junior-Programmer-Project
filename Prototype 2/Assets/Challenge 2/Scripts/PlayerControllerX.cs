using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private InputAction _spawnAction;

    public float cooldown = 2f;
    public bool onCooldown = false;
    public float ticks = 0.0f;
    void Start()
    {
        _spawnAction = InputSystem.actions.FindAction("Jump");
    }
    // Update is called once per frame
    void Update()
    {
        if (onCooldown)
        {
            ticks += Time.deltaTime;
            if (ticks >= cooldown)
            {
                onCooldown = false;
                ticks = 0.0f;
            }
        }

        // On spacebar press, send dog
        if (_spawnAction.triggered && !onCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            onCooldown = true;
        }
    }
}
