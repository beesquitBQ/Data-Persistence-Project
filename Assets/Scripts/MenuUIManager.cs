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
        Debug.Log("MenuUIManager Start called");
        if (MainManager.Instance == null)
        {
            Debug.LogError("MainManager is not initialized in MenuUIManager Start");
            return;
        }

        if (playerNameInput == null)
        {
            Debug.LogError("playerNameInput is not assigned in MenuUIManager");
            return;
        }

        if (!string.IsNullOrEmpty(MainManager.Instance.playerName))
        {
            playerNameInput.text = MainManager.Instance.playerName;
            Debug.Log($"Loaded player name: {MainManager.Instance.playerName}");
        }
        else
        {
            Debug.Log("MainManager.Instance.playerName is empty");
        }
    }

    public void SetPlayerName()
    {
        Debug.Log("SetPlayerName called");
        if (MainManager.Instance == null)
        {
            Debug.LogError("MainManager is not initialized in SetPlayerName()");
            return;
        }

        if (playerNameInput == null)
        {
            Debug.LogError("playerNameInput is null in SetPlayerName()");
            return;
        }

        MainManager.Instance.playerName = playerNameInput.text;
        Debug.Log($"Player name set to: {MainManager.Instance.playerName}");
        MainManager.Instance.SaveHighscore();
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

