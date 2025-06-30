using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _animalPrefabs;
    [SerializeField] private float _spawnRangeX = 20;
    [SerializeField] private float _spawnPosZ = 20;
    [SerializeField] private float _startDelay = 2;
    [SerializeField] private float _spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnPosZ);
        int animalIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[animalIndex], spawnPos, _animalPrefabs[animalIndex].transform.rotation);
    }
}
