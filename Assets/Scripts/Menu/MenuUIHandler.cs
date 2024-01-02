using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text scoreText;

    public void ShowName() 
    {
        scoreText.text = "Best Score : " + GameManager.Instance.GetName() + " : 0"; 
    }

    public void StartNewGame(int sceneID) 
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Quit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}