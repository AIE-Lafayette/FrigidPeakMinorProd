using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInputBehavior : MonoBehaviour
{
    [SerializeField]
    private bool _onMainMenu = false;


    // Pause Menu
    [SerializeField]
    private GameObject _pauseMenu;
    private bool _pauseMenuShown = false;
    private bool _isPaused = false;

    public bool IsPaused { get { return _isPaused; } set { _isPaused = value; } }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstBuildScene");
    }

    public void QuitGame()
    {
        Debug.Log("Application Stopped");
        Application.Quit();
    }

    public void ToMainMenu(string menuName)
    {
        GameManagerScript.Reinitialize();
        SceneManager.LoadScene(menuName);
        Time.timeScale = 1; //Resets the time scale
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
    }

    public void ShowPauseMenu()
    {
        if (!_onMainMenu)
        {
            if (!_pauseMenu.activeInHierarchy)
            {
                _pauseMenu.SetActive(true);
                Time.timeScale = 0;
                InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            }
            else
            {
                _pauseMenu.SetActive(false);
                Time.timeScale = 1;
                InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            }
        }
    }
}
