using UnityEngine;

// INHERITANCE
public class EnemyController : UnitController
{
    private GameObject _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _rigidbody.maxLinearVelocity = _maxSpeed;
    }

    // POLYMORPHISM
    protected override void Move()
    {
        if (_player == null)
            return;

        Vector3 direction = _player.transform.position - transform.position;
        _rigidbody.AddForce(direction * _moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }

    // POLYMORPHISM
    protected override void OutOfBoundsHandler()
    {
        Destroy(gameObject);
    }
}
