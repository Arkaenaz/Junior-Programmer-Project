using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highestWaveText;
    [SerializeField] private TMP_InputField _nameInputField;

    private void Start()
    {
        DataManager.Instance.LoadData();

        DataManager.PlayerEntry entry = DataManager.Instance.GetEntry();
        if (entry != null)
        {
            _highestWaveText.text = $"Highest Wave : {entry.Name} : Wave {entry.Wave}";
        }
    }

    public void OnStartButtonClicked()
    {
        DataManager.Instance.Name = _nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
