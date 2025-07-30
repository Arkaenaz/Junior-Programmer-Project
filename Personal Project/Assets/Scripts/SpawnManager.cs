using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveNumberText;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private float _spawnRange = 9;

    private int _enemyCount = 0;
    private int _waveNumber = 1;
    private bool _canSpawn = true;
    // ENCAPSULATION
    public bool CanSpawn
    {
        get => _canSpawn;
        set => _canSpawn = value;
    }

    // ENCAPSULATION
    public int WaveNumber
    {
        get => _waveNumber;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _waveNumberText.text = $"Wave {_waveNumber}";
        SpawnEnemyWave(_waveNumber);
    }

    // ABSTRACTION
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // ABSTRACTION
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, _enemyPrefabs.Count);
            GameObject enemyPrefab = _enemyPrefabs[randomIndex];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
        if (_enemyCount == 0)
        {
            if (!_canSpawn)
                return;
            _waveNumber++;
            _waveNumberText.text = $"Wave {_waveNumber}";
            SpawnEnemyWave(_waveNumber);
        }
    }
}