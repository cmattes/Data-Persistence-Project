using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int HighScore = 0;
    public string HighScoreName = "Name";
    public string CurrentName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadAllData();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScoreName;
        public string CurrentName;
    }

    public void SaveAllData()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighScoreName = HighScoreName;
        data.CurrentName = CurrentName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadAllData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            HighScoreName = data.HighScoreName;
            CurrentName = data.CurrentName;
        }

    }
}
