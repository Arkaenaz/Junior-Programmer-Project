using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] SpawnManager _spawnManager;
    [SerializeField] private GameObject _gameOverContainer;
    [SerializeField] private TextMeshProUGUI _highestWaveText;

    public void GameOver()
    {
        _gameOverContainer.SetActive(true);
        _spawnManager.CanSpawn = false;

        DataManager.Instance.TryAddHighestWave(_spawnManager.WaveNumber);
        DataManager.Instance.SaveData();

        if (DataManager.Instance.Entry != null)
        {
            _highestWaveText.text = $"Highest Wave : {DataManager.Instance.Entry.Name} : {DataManager.Instance.Entry.Wave}";
        }
    }
}
