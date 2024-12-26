using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[DefaultExecutionOrder(-10)]
public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public string playerName;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;

    public int bestScore;
    public string bestPlayerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighscore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateBestScoreText();
    }

    private void UpdateScoreText()
    {
        if (ScoreText != null)
        {
            ScoreText.text = $"Score : {playerName} : {m_Points}";
        }
    }

    private void UpdateBestScoreText()
    {
        if (BestScoreText != null)
        {
            BestScoreText.text = $"Best Score : {bestPlayerName} : {bestScore}";
        }
    }

    public void AddPoint(int point)
    {
        m_Points += point;
        UpdateScoreText();

        if (m_Points > bestScore)
        {
            bestScore = m_Points;
            bestPlayerName = playerName;
            UpdateBestScoreText();
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
        if (GameOverText != null)
        {
            GameOverText.SetActive(true);
        }

        if (m_Points > bestScore)
        {
            bestScore = m_Points;
            bestPlayerName = playerName;
            SaveHighscore();
        }
        UpdateBestScoreText();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}
