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
    [SerializeField]
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

        if (!IsClimbing)
            newMoveDir = new Vector3(MoveDirection.x, 0, 0);

        // Set the velocity
        Velocity = newMoveDir * _speed;
    }

    public void Jump()
    {
        //if the player is grounded
        if (_isGrounded)
        {
            SoundManagerBehavior.setSoundClip(_jumpClip);
            SoundManagerBehavior.PlayClip = true;
            // Add a force to push the player upward.
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (!IsGrounded)
            Velocity /= 2;

        // Move The position of the rigidbody
        transform.position += Velocity * Time.fixedDeltaTime;

        //Moves the players forward according to rotation
        if (Velocity.magnitude > 0)
            transform.forward = new Vector3(Velocity.normalized.x, 0);
    }

    public void ClimbRope()
    {
        _rigidBody.velocity = Vector3.zero;
        _isClimbing = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(new Ray(transform.position, transform.forward));
    }
}
