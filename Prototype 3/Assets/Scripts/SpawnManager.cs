using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Vector3 _spawnPosition = new Vector3(25, 0, 0);
    [SerializeField] private float _startDelay = 2f;
    [SerializeField] private float _repeatRate = 2f;

    private PlayerController _playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (_playerControllerScript.gameOver == false)
            Instantiate(_obstaclePrefab, _spawnPosition, _obstaclePrefab.transform.rotation);
    }
}
