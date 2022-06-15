using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementBehavior _playermovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            _playermovement.IsGrounded = true;
            _playermovement.IsClimbing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
            _playermovement.IsGrounded = false;
    }
}
