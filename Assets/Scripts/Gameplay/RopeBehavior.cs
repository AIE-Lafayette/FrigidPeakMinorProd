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
            _playerMovement.RopeInRange = true;
            _playerMovement.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            _playerMovement = other.GetComponent<PlayerMovementBehavior>();
            _playerMovement.RopeInRange = false;
            _playerMovement.IsClimbing = false;
            _playerMovement.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
