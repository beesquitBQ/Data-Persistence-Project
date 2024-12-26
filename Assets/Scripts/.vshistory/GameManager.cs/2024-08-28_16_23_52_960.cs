//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public Text scoreText;
//    public Text highscoreText;
//    private int currentScore = 0;

//    private void Start()
//    {
//        UpdateScoreText();
//        UpdateHighscoreText();
//    }

//    public void AddScore(int points)
//    {
//        currentScore += points;
//        UpdateScoreText();

//        if (MainManager.Instance != null)
//        {
//            MainManager.Instance.UpdateHighscore(currentScore);
//            UpdateHighscoreText();
//        }
//    }

//    private void UpdateScoreText()
//    {
//        if (scoreText != null && MainManager.Instance != null)
//        {
//            scoreText.text = $"Score: {MainManager.Instance.playerName} : {currentScore}";
//        }
//    }

//    private void UpdateHighscoreText()
//    {
//        if (highscoreText != null && MainManager.Instance != null)
//        {
//            highscoreText.text = $"Best Score: {MainManager.Instance.bestPlayerName} : {MainManager.Instance.bestScore}";
//        }
//    }
//}
