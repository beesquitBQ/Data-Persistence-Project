using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;
    private bool m_GameOver = false;

    void Start()
    {
        SetupGame();
        UpdateScoreText();
        UpdateBestScoreText();
    }

    void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void SetupGame()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
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

    void StartGame()
    {
        m_Started = true;
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();

        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
    }

    void AddPoint(int point)
    {
        m_Points += point;
        UpdateScoreText();

        if (m_Points > MainManager.Instance.bestScore)
        {
            MainManager.Instance.bestScore = m_Points;
            MainManager.Instance.bestPlayerName = MainManager.Instance.playerName;
            UpdateBestScoreText();
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        if (m_Points > MainManager.Instance.bestScore)
        {
            MainManager.Instance.bestScore = m_Points;
            MainManager.Instance.bestPlayerName = MainManager.Instance.playerName;
            MainManager.Instance.SaveHighscore();
        }
        UpdateBestScoreText();
    }

    private void UpdateScoreText()
    {
        ScoreText.text = $"Score : {MainManager.Instance.playerName} : {m_Points}";
    }

    private void UpdateBestScoreText()
    {
        BestScoreText.text = $"Best Score : {MainManager.Instance.bestPlayerName} : {MainManager.Instance.bestScore}";
    }
}
