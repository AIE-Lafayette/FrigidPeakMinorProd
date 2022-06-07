using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioClip _climbSound;
    private PlayerMovementBehavior _playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        //if the tag of the collider is the player
        if (other.CompareTag("player"))
        {
            _playerMovement = other.GetComponent<PlayerMovementBehavior>();
            _playerMovement.CanGoVertical = true;
            _playerMovement.IsOnRope = true;
            _playerMovement.Force.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            _playerMovement = other.GetComponent<PlayerMovementBehavior>();
            _playerMovement.CanGoVertical = false;
            _playerMovement.IsOnRope = false;
            _playerMovement.Force.enabled = true;
        }
    }
}
