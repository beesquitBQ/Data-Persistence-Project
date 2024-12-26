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

    private void Start()
    {
        if (MainManager.Instance == null)
        {
            Debug.LogWarning("MainManager is not initialized. Creating a new instance.");
            GameObject mainManagerObject = new GameObject("MainManager");
            mainManagerObject.AddComponent<MainManager>();
        }

        if (playerNameInput != null)
        {
            if (!string.IsNullOrEmpty(MainManager.Instance.playerName))
            {
                playerNameInput.text = MainManager.Instance.playerName;
            }
        }
        else
        {
            Debug.LogError("playerNameInput is not assigned in MenuUIManager");
        }
    }

    public void SetPlayerName()
    {
        if (MainManager.Instance != null && playerNameInput != null)
        {
            MainManager.Instance.playerName = playerNameInput.text;
            Debug.Log($"Player name set to: {MainManager.Instance.playerName}");
        }
        else
        {
            Debug.LogError("MainManager is not initialized or playerNameInput is null in SetPlayerName()");
        }
    }

    public void StartNew()
    {
        SetPlayerName();
        SceneManager.LoadScene(1); // Загрузка сцены игры
    }

    public void Exit()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SaveHighscore();
        }
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

