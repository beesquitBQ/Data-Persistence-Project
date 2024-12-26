using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(0)]
public class MenuUIManager : MonoBehaviour
{
    public InputField playerNameInput;
    public Text highscoreText;

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        if (MainManager.Instance == null)
        {
            Debug.LogError("MainManager is not initialized");
            return;
        }

        if (playerNameInput != null)
        {
            playerNameInput.text = MainManager.Instance.playerName;
        }

        UpdateHighscoreText();
    }

    public void SetPlayerName()
    {
        if (MainManager.Instance != null && playerNameInput != null)
        {
            MainManager.Instance.playerName = playerNameInput.text;
            Debug.Log($"Player name set to: {MainManager.Instance.playerName}");
        }
    }

    private void UpdateHighscoreText()
    {
        if (highscoreText != null && MainManager.Instance != null)
        {
            highscoreText.text = $"Best Score: {MainManager.Instance.bestPlayerName} : {MainManager.Instance.bestScore}";
        }
    }

    public void StartNew()
    {
        Debug.Log("StartNew called");
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SaveHighscore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

