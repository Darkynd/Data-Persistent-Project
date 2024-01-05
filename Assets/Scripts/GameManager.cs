using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private string playerName;
    private int highScore;
    private string highScoreString;

    [System.Serializable]
    class SaveData 
    {
        public string playerName;
        public int highScore;
        public string highScoreString; 
    }

    public void SaveHighScore() 
    {
        SaveData data = new SaveData();       
        data.playerName = playerName;      
        data.highScore = highScore;        
        data.highScoreString = highScoreString;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "highscores.json", json);
    }

    public void LoadHighScore() 
    {
        string path = Application.persistentDataPath + "highscores.json";

        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScore = data.highScore;
            highScoreString = data.highScoreString;
        }
    }

    public string GetCurrentPlayerName() { return playerName; }

    public void SetCurrentPlayerName(string name) { playerName = name; } 

    public int GetHighScore() { return highScore; }

    public string GetHighScoreString() { return highScoreString; }

    public void SetHighScore(string finalScoreString, int finalScore) 
    {
        highScoreString = finalScoreString;
        highScore = finalScore;
    } 

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
       
        Instance = this;
        DontDestroyOnLoad(gameObject);       
        LoadHighScore();
    }
}
