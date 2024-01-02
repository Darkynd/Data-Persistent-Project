using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public InputField inputName;
    public Text scoreText;

    private string playerName;
    private int score;

    public void ShowName()
    {
        scoreText.text = "Best Score : " + Instance.GetName() + " : 0";
    }

    public void SetName() 
    {
        playerName = inputName.text;
        Debug.Log(playerName);
    }

    public string GetName() 
    {
        return playerName;
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
    }
}
