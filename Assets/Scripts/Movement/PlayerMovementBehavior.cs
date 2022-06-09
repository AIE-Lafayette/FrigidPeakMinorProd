using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private ConstantForce _force;
    private Rigidbody _rigidBody;
    private Vector3 _originalPos;

    // Movement Vars
    private Vector3 _velocity;
    private Vector3 _moveDir;
    private bool _isClimbing;
    private bool _ropeInRange;

    //Jumping Vars
    [SerializeField]
    private float _jumpForce = 2.0f;
    [SerializeField]
    private AudioClip _jumpClip;
    private Vector3 _jumpHeight;
    private bool _isGrounded;

    public ConstantForce Force { get { return _force; } private set { _force = value; } }
    public Vector3 Velocity { get { return _velocity; } private set { _velocity = value; } }
    public float Speed { get { return _speed; } set { _speed = value; } }
    public bool IsClimbing { get { return _isClimbing; } set { _isClimbing = value; } }
    public bool RopeInRange { get { return _ropeInRange; } set { _ropeInRange = value; } }
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
    public Vector3 MoveDirection { get { return _moveDir; } set { _moveDir = value; } }

    private void Awake()
    {
        //Get the rigidbody component
        _rigidBody = GetComponent<Rigidbody>();
        Force = GetComponent<ConstantForce>();
        _jumpHeight = new Vector3(0.0f, 1.0f);
        _originalPos = transform.position;
    }

    public void Move()
    {
        Vector3 newMoveDir = MoveDirection;

        // Set the velocity
        Velocity = newMoveDir * _speed * Time.deltaTime;
    }

    public void Jump()
    {
        //if the player is grounded
        if (_isGrounded)
        {
            SoundManagerBehavior.setSoundClip(_jumpClip);
            SoundManagerBehavior.PlayClip = true;
            // Add a force to push the player upward.
            _rigidBody.AddForce(_jumpHeight * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Move The position of the rigidbody
        _rigidBody.velocity += Velocity * Speed;
        //Debug.Log(_rigidBody.velocity.magnitude);

        if (_rigidBody.velocity.magnitude > Speed)
            _rigidBody.velocity = _rigidBody.velocity.normalized * Speed;

        //Moves the players forward according to rotation
        if (Velocity.magnitude > 0)
            transform.forward = new Vector3(Velocity.normalized.x, 0);
    }

    public void ClimbRope()
    {
        _rigidBody.velocity = Vector3.zero * Speed * Time.deltaTime;
        _isClimbing = true;
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
