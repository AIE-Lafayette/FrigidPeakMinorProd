using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviors : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementBehavior _playerMovement;
    [SerializeField]
    private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed", _playerMovement.GetComponent<Rigidbody>().velocity.magnitude);

        if (_playerMovement.IsClimbing)
            _animator.SetBool("isClimbing", true);
        else
            _animator.SetBool("isClimbing", false);
    }
}
