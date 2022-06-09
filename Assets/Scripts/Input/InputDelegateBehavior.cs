using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehavior : MonoBehaviour
{
    private PlayerControls _playerControls;
    private PlayerMovementBehavior _playerMovement;
    private MenuInputBehavior _menuBehavior;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerMovement = GetComponent<PlayerMovementBehavior>();
        _menuBehavior = GameObject.FindWithTag("Canvas").GetComponent<MenuInputBehavior>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerControls.MenuControls.PauseMenu.performed += context => _menuBehavior.ShowPauseMenu();
        _playerControls.Player.Jump.performed += context => _playerMovement.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _playerMovement.MoveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();

        if (_playerMovement.RopeInRange && _playerMovement.MoveDirection.y > 0)
            _playerMovement.ClimbRope();

        _playerMovement.Move();
    }
}
