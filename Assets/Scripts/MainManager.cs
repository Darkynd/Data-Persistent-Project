using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text scoreText;
    public Text highScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    // Start is called before the first frame update
    void Start()
    {       
        highScoreText.text = GameManager.Instance.GetHighScoreString();
        scoreText.text = $"{GameManager.Instance.GetCurrentPlayerName()} : Score: {m_Points}";

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // Destroy(GameObject.Find("DDOL"));
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        scoreText.text = $"{GameManager.Instance.GetCurrentPlayerName()} : Score : {m_Points}";

        if (m_Points > GameManager.Instance.GetHighScore())
        {
            GameManager.Instance.SetHighScore($"Best Score : {GameManager.Instance.GetCurrentPlayerName()} : Score : {m_Points}", m_Points);
            highScoreText.text = $"Best Score : {GameManager.Instance.GetCurrentPlayerName()} : Score : {m_Points}";
            
        }
        else return;
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        GameManager.Instance.SaveHighScore();
    }
}
