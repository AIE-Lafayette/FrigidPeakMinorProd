using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    //Refrence to the PlayerMovement script
    private PlayerMovementBehavior _playerMovement;
    private MenuInputBehavior _menuInput;

    private void Awake()
    {
        //Retrieve the movementbehavior script from the object
        _playerMovement = GetComponent<PlayerMovementBehavior>();

        //Change the canvas to be the game manager once we put everything altogether
        _menuInput = GameObject.Find("Canvas").GetComponent<MenuInputBehavior>();
    }

    private void Update()
    {
        // If the game is not paused
        if (!_menuInput.IsPaused)
        {
            // Set the player move direction to a new vector 3
            _playerMovement.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        //If the cancel button is pressed
        if (Input.GetButtonDown("Cancel"))
        {
            //Call the showPauseMenu method in the menuInput Script.
            _menuInput.ShowPauseMenu();
        }
    }
}
