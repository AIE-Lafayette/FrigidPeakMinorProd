using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAveBehaviour : MonoBehaviour
{
    PlayerMovementBehavior _playersMovement;
    private void OnCollisionEnter(Collision collision)
    {
        _playersMovement = collision.other.GetComponent<PlayerMovementBehavior>();
    }

    private void OnCollisionExit(Collision collision)
    {   
        //Logic 
    }
}