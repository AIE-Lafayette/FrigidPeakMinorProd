using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidBody;

    // Movement Vars
    private Vector3 _moveDir;
    private bool _canGoVertical;

    //Jumping Vars
    [SerializeField]
    private float _jumpForce = 2.0f;
    private Vector3 _jumpHeight;
    private bool _isGrounded;

    public Rigidbody rigidbody { get { return _rigidBody; } }
    public Vector3 MoveDirection { get { return _moveDir; } set { _moveDir = value; } }
    public bool CanGoVertical { get { return _canGoVertical; } set { _canGoVertical = value; } }

    public float JumpForce { get { return _jumpForce; } }
    public Vector3 JumpHeight { get { return _jumpHeight; } }
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }

    private void Awake()
    {
        //Get the rigidbody component
        _rigidBody = GetComponent<Rigidbody>();
        _canGoVertical = false;
        _jumpHeight = new Vector3(0.0f, 0.5f);
    }

    private void FixedUpdate()
    {
        Vector3 newMoveDir = MoveDirection;

        if (!_canGoVertical)
        {
            newMoveDir = new Vector3(MoveDirection.x, 0, 0);
        }

        // Set the velocity
        Vector3 velocity = newMoveDir * _speed * Time.deltaTime;

        // Move The position of the rigidbody
        _rigidBody.MovePosition(transform.position + velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the collider has the tag ground
        if (collision.gameObject.CompareTag("ground"))
        {
            //Set isGrounded to true
            _isGrounded = true;
        }

        // If the collider has the tag snowball 
        if (collision.gameObject.CompareTag("snowball"))
        {
            //Lose a life
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the collider has the tag ground
        if (collision.gameObject.CompareTag("ground"))
        {
            //Set isGrounded to true
            _isGrounded = false;
        }
    }
}
