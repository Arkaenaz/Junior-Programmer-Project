using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private const int MAX_HIGH_SCORES = 10;
    public static DataManager Instance { get; private set; }

    public string Name = "";
    public List<HighScoreEntry> HighScores = new List<HighScoreEntry>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class Data
    {
        public List<HighScoreEntry> HighScores = new List<HighScoreEntry>();
    }

    [System.Serializable]
    public class HighScoreEntry
    {
        public string Name;
        public int Score;
    }

    public HighScoreEntry GetBestScore()
    {
        return HighScores.Count > 0 ? HighScores[0] : null;
    }

    public void AddHighScore(int score)
    {
        HighScoreEntry entry = new HighScoreEntry();
        entry.Name = Name;
        entry.Score = score;

        HighScores.Add(entry);

        HighScores = HighScores.OrderByDescending(scoreEntry => scoreEntry.Score).ToList();

        if (HighScores.Count > MAX_HIGH_SCORES)
        {
            HighScores = HighScores.Take(MAX_HIGH_SCORES).ToList();
        }

        SaveHighScores();
    }

    public void SaveHighScores()
    {
        Data data = new Data();
        data.HighScores = new List<HighScoreEntry>(HighScores);

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/highscores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            HighScores = data.HighScores;
        }
    }
}
