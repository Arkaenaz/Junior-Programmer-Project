using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _powerUpStrength = 15.0f;
    [SerializeField] private GameObject _focalPoint;
    [SerializeField] private GameObject _powerupIndicator;

    private Rigidbody _playerRb;

    private InputAction _moveInput;

    private bool _hasPowerup = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = _moveInput.ReadValue<Vector2>().y;
        _playerRb.AddForce(_focalPoint.transform.forward * _speed * forwardInput);
        _powerupIndicator.transform.position = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            _hasPowerup = true;
            Destroy(other.gameObject);
            _powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + _hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * _powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        _hasPowerup = false;
        _powerupIndicator.gameObject.SetActive(false);
    }
}
