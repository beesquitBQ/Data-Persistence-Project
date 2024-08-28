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
    public InputField playerName;

    public void NewName(string playerName)
    {
        MainManager.Instance.name = playerName;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SavePlayerName()
    {

    }
    
    public void LoadPlayerName()
    {

    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

