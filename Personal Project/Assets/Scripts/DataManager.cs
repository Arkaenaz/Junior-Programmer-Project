using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    private string _name = "";
    // ENCAPSULATION
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    private PlayerEntry _entry;
    // ENCAPSULATION
    public PlayerEntry Entry
    {
        get => _entry;
        set => _entry = value;
    }

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
        public PlayerEntry PlayerEntry;
    }

    [System.Serializable]
    public class PlayerEntry
    {
        public string Name;
        public int Wave;
    }

    public PlayerEntry GetEntry()
    {
        return Entry;
    }

    public void TryAddHighestWave(int wave)
    {
        if (Entry == null || wave > Entry.Wave)
        {
            Entry = new PlayerEntry();
            Entry.Name = Name;
            Entry.Wave = wave;

            SaveData();
        }
    }

    public void SaveData()
    {
        Data data = new Data();
        data.PlayerEntry = Entry;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.persistentDataPath + "/highest_wave.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/highest_wave.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            Entry = data.PlayerEntry;
        }
    }
}
