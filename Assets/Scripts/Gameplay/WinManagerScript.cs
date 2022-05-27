using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class WinManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _winScreen; //The win screen

    private void OnCollisionEnter(Collision collision)
    {
        //On collision with the player display the win screen
        if (collision.gameObject.tag == "player")
        {
            _winScreen.SetActive(true); //Set the win screen to be active
            Time.timeScale = 0; //Set time scale to zero
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate; //Change the update mode to dynamic update
        }
    }

    private void Update()
    {
        if (GameManagerScript.CurrentLives == PlayersLiveState.DEAD) //If the player lives are zero
        {
            _winScreen.SetActive(true); //Set win screen to active
            Time.timeScale = 0; //Set time scale to zero
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate; //Change tje update mode to fynamic update
        }
    }
}
