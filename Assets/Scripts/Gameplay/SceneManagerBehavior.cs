using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagerBehavior : MonoBehaviour
{
    public static void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameManagerScript.CurrentLives = 3;
        //SceneManager.LoadScene("StartScreen");
        SceneManager.LoadScene("MichaelTestScene");
        Time.timeScale = 1;
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
    }
}
