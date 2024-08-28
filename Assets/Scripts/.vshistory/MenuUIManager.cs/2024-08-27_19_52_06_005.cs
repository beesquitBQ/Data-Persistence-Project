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
        if (MainManager.Instance != null && !string.IsNullOrEmpty(MainManager.Instance.playerName))
        {
            playerNameInput.text = MainManager.Instance.playerName;
        }
    }

    public void SetPlayerName()
    {
        if (MainManager.Instance != null && playerNameInput != null)
        {
            MainManager.Instance.playerName = playerNameInput.text;
        }
        //else
        //{
        //    Debug.LogWarning("MainManager.Instance or playerNameInput is null in SetPlayerName()");
        //}
    }


    public void StartNew()
    {
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

