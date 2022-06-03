using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidBody;
    private Vector3 _originalPos;

    // Movement Vars
    private Vector3 _velocity;
    private Vector3 _moveDir;
    private bool _canGoVertical;
    private bool _isOnRope;

    //Jumping Vars
    [SerializeField]
    private float _jumpForce = 2.0f;
    private Vector3 _jumpHeight;
    private bool _isGrounded;

    public float Speed { get { return _speed; } set { _speed = value; } }
    public bool IsOnRope { get { return _isOnRope; } set { _isOnRope = value; } }
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
    public Vector3 MoveDirection { get { return _moveDir; } set { _moveDir = value; } }
    public bool CanGoVertical { get { return _canGoVertical; } set { _canGoVertical = value; } }

    private void Awake()
    {
        //Get the rigidbody component
        _rigidBody = GetComponent<Rigidbody>();
        _canGoVertical = false;
        _jumpHeight = new Vector3(0.0f, 0.5f);
        _originalPos = transform.position;
    }

    public void Move()
    {
        Vector3 newMoveDir = MoveDirection;
        if (_isGrounded || _isOnRope)
        {
            if (!_canGoVertical)
            {
                //Stopping any upward movement
                newMoveDir = new Vector3(MoveDirection.x, 0, 0);
            }

            // Set the velocity
            _velocity = newMoveDir * _speed * Time.deltaTime;
        }
    }

    public void Jump()
    {
        //if the player is grounded
        if (_isGrounded)
        {
            // Add a force to push the player upward.
            _rigidBody.AddForce(_jumpHeight * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Move The position of the rigidbody
        _rigidBody.MovePosition(transform.position + _velocity);

        //Moves the players forward according to rotation
        if (_velocity.magnitude > 0)
        {
            transform.forward = new Vector3(_velocity.normalized.x, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the collider has the tag ground
        if (collision.gameObject.CompareTag("ground"))
            //Set isGrounded to true
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the collider has the tag ground
        if (collision.gameObject.CompareTag("ground"))
            //Set isGrounded to false
            _isGrounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(new Ray(transform.position, transform.forward));
    }
}
