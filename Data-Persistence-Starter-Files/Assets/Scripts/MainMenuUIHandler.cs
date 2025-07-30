using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_bestScoreText;
    [SerializeField] private TMP_InputField m_nameInputField;
    [SerializeField] private GameObject m_highScoresContainer;
    [SerializeField] private TextMeshProUGUI m_highScoresTextObject;
    private void Start()
    {
        DataManager.Instance.LoadHighScores();

        DataManager.HighScoreEntry entry = DataManager.Instance.GetBestScore();
        if (entry != null)
        {
            m_bestScoreText.text = $"Best Score : {entry.Name} : {entry.Score}";
        }

        int i = 0;
        foreach (DataManager.HighScoreEntry scoreEntry in DataManager.Instance.HighScores)
        {
            i++;
            TextMeshProUGUI score = Instantiate(m_highScoresTextObject, m_highScoresContainer.transform);
            score.text = $"{i} : {scoreEntry.Name} : {scoreEntry.Score}";
        }
    }

    public void OnStartButtonClicked()
    {
        DataManager.Instance.Name = m_nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked()
    {
        DataManager.Instance.SaveHighScores();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
