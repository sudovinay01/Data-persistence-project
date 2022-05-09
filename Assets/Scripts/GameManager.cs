using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace;

    public string currentPlayerName;

    public string bestScorePlayer="";
    public int bestScore=-1;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instace != null)
        {
            Destroy(gameObject);
            return;
        }
        Instace = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    class SaveData
    {
        public string bestScorePlayer_Save;
        public int bestScore_Save;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScorePlayer_Save = Instace.bestScorePlayer;
        data.bestScore_Save = Instace.bestScore;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath+"/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Instace.bestScorePlayer = data.bestScorePlayer_Save;
            Instace.bestScore = data.bestScore_Save;
        }
    }
}
