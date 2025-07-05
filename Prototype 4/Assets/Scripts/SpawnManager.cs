using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private float _spawnRange = 9;

    private int _enemyCount = 0;
    private int _waveNumber = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(_waveNumber);
        Instantiate(_powerupPrefab, GenerateSpawnPosition(), _powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (_enemyCount == 0)
        {
            _waveNumber++;
            Instantiate(_powerupPrefab, GenerateSpawnPosition(), _powerupPrefab.transform.rotation);
            SpawnEnemyWave(_waveNumber);
        }
    }
}
