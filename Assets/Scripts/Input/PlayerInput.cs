using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Refrence to the PlayerMovement script
    private PlayerMovementBehavior _playerMovement;

    private void Awake()
    {
        //Retrieve the movementbehavior script from the object
        _playerMovement = GetComponent<PlayerMovementBehavior>();
    }

    private void Update()
    {
        _playerMovement.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButton("Jump"))
        {
            if (_playerMovement.IsGrounded)
            {
                _playerMovement.rigidbody.AddForce(_playerMovement.JumpHeight * _playerMovement.JumpForce, ForceMode.Impulse);
            }
        }
    }
}
