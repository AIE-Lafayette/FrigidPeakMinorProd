using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviors : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementBehavior _playerMovement;
    [SerializeField]
    private PlayerDeathBehavior _playerDeath;
    [SerializeField]
    private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isGrounded", _playerMovement.IsGrounded);
        _animator.SetFloat("speed", _playerMovement.Velocity.magnitude);

        if (_playerMovement.IsClimbing)
            _animator.SetBool("isClimbing", true);
        else
            _animator.SetBool("isClimbing", false);
    }
}
