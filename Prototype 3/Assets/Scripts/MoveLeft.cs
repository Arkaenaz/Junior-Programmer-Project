using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController _playerControllerScript;
    private float _speed = 20f;
    private float _leftBound = -15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerControllerScript.gameOver == false)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
