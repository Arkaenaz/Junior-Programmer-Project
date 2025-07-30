using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rangeX = 10f;
    [SerializeField] private float _rangeY = -10f;
    private Rigidbody _playerRb;

    private InputAction _moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _moveInput = InputSystem.actions.FindAction("Move");
        _playerRb.maxLinearVelocity = _maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ConstrainPlayerPosition();
        MovePlayer();
        DestroyOutOfBounds();
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.x < -_rangeX || transform.position.x > _rangeX)
        {
            float x = Mathf.Clamp(transform.position.x, -_rangeX, _rangeX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            _playerRb.linearVelocity = new Vector3(0, _playerRb.linearVelocity.y, _playerRb.linearVelocity.z); // Reset horizontal velocity
        }
    }

    void MovePlayer()
    {
        float horizontalInput = _moveInput.ReadValue<Vector2>().x;
        float verticalInput = _moveInput.ReadValue<Vector2>().y;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        _playerRb.AddForce(movement * _moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.y < _rangeY)
        {
            Debug.Log("Player out of bounds, destroying player.");
            Debug.Log("Game Over!");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
