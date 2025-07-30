using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private SpawnManager _spawnManager;
    public void OnRetryButtonClicked()
    {
        DataManager.Instance.TryAddHighestWave(_spawnManager.WaveNumber);
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked()
    {
        DataManager.Instance.TryAddHighestWave(_spawnManager.WaveNumber);
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);
    }
}
