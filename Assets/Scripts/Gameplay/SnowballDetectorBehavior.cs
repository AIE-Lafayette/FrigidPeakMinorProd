using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDetectorBehavior : MonoBehaviour
{
    PlayerMovementBehavior _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponentInParent<PlayerMovementBehavior>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("snowball"))
        {
            if (!_playerMovement.IsGrounded && !_playerMovement.IsClimbing)
                GameManagerScript.IncreaseScore(100);
        }
    }
}
