using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    private PlayerMovementBehavior _playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        //if the tag of the collider is the player
        if (other.CompareTag("player"))
        {
            _playerMovement = other.GetComponent<PlayerMovementBehavior>();
            _playerMovement.CanGoVertical = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            _playerMovement = other.GetComponent<PlayerMovementBehavior>();
            _playerMovement.CanGoVertical = false;
        }
    }
}