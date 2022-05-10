using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowPauseMenu()
    {
        if (!_onMainMenu)
        {
            if (!_pauseMenuShown)
            {
                _pauseMenu.SetActive(true);
                _pauseMenuShown = true;
                IsPaused = true;
            }
            else
            {
                _pauseMenu.SetActive(false);
                _pauseMenuShown = false;
                IsPaused = false;
            }
        }
    }
}
