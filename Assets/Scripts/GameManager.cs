using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public InputField inputName;
    public Text scoreText;

    private string currentPlayerName;
    private string bestPlayerName;
    private int currentPlayerScore;
    private int highScore;

    public void ShowName()
    {
        scoreText.text = "Best Score : " + Instance.GetName() + " : 0";
    }

    public void SetName() 
    {
        currentPlayerName = inputName.text;       
    }

    public string GetName() 
    {
        return currentPlayerName;
    }

    public int GetHighScore() 
    {
        return highScore;
    }

    public void SetBestPlayerScore(int finalScore) 
    {
        currentPlayerScore = finalScore;
        Debug.Log(currentPlayerScore);

        if (currentPlayerScore > highScore) 
        {
            highScore = currentPlayerScore;
            currentPlayerScore = 0;
        }
    }

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        currentPlayerScore = 0;
        highScore = 0;
        Debug.Log(highScore);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
