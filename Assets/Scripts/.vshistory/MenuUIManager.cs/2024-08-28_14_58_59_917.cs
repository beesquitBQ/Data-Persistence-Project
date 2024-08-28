using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public InputField playerNameInput;

    private void Start()
    {
        Debug.Log("MenuUIManager Start called");
        if (MainManager.IsInitialized())
        {
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
        else
        {
            Debug.LogError("MainManager is not initialized in MenuUIManager Start");
        }
    }

    public void SetPlayerName()
    {
        Debug.Log("SetPlayerName called");
        if (MainManager.IsInitialized())
        {
            if (playerNameInput != null)
            {
                MainManager.Instance.playerName = playerNameInput.text;
                Debug.Log($"Player name set to: {MainManager.Instance.playerName}");
            }
            else
            {
                Debug.LogError("playerNameInput is null in SetPlayerName()");
            }
        }
        else
        {
            Debug.LogError("MainManager is not initialized in SetPlayerName()");
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

