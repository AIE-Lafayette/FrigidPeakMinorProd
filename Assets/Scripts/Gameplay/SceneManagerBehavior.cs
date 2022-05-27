using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagerBehavior : MonoBehaviour
{
    /// <summary>
    /// Restarts the current level
    /// </summary>
    public static void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// <summary>
    /// Closes the game
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Restarts the game 
    /// </summary>
    public void RestartGame()
    {
        //GameManagerScript.CurrentLives = 3; //Resets the player's lives to 3
        //SceneManager.LoadScene("StartScreen"); //Loads the start screen
        SceneManager.LoadScene("MichaelTestScene");
        Time.timeScale = 1; //Resets the time scale
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate; //Resets the update mode.
    }
}
