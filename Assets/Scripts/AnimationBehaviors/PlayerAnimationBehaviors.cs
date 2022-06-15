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

    private void Awake()
    {
        _playerDeath.OnDeath += () => _animator.SetTrigger("onDeath");
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovement.IsClimbing)
            _animator.SetBool("isClimbing", true);
        else
            _animator.SetBool("isClimbing", false);

        _animator.SetFloat("speed", _playerMovement.Velocity.magnitude);
        _animator.SetBool("isGrounded", _playerMovement.IsGrounded);
    }
}
