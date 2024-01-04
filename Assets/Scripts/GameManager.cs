using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public InputField inputName;
    public Text highScoreText;  

    private string currentPlayerName;
    private string bestPlayerName;
    private int highScore;

    public string GetCurrentPlayerName() { return currentPlayerName; }

    public void SetCurrentPlayerName() 
    {
        currentPlayerName = inputName.text;     
    } 

    public int GetHighScore() { return highScore; }

    public void SetHighScore(int finalScore) => highScore = finalScore;

    public string GetBestPlayerName() { return bestPlayerName; }

    public void SetBestPlayerName() => bestPlayerName = currentPlayerName;

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        // highScore = 0;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
