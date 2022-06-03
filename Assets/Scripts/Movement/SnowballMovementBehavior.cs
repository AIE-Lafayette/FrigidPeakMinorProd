using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 _velocity;
    [SerializeField]
    private Vector3 _moveDirection = Vector3.left; //The snowball's move direction defaults to left {-1, 0, 0}
    private bool _isGrounded;

    /// <summary>
    /// The speed the snowball moves
    /// </summary>
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    /// <summary>
    /// The snowball's velocity
    /// </summary>
    public Vector3 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    private void Update()
    {
        if (_isGrounded) //If the snowball is grounded
        {
            Velocity = _moveDirection.normalized * Speed; //Set velocity to the normalized move direction times speed
            transform.position += Velocity * Time.deltaTime; //Increase the position by velocity times delta time
        } 
    }

    private void OnCollisionStay(Collision collision)
    {
        //While colliding with the ground isGrounded is true
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //When you are no longer colliding with the ground isGrounded is false
        _isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //On collision with the barrier 
        if (other.tag == "Barrier")
        {
            if (_moveDirection == Vector3.left) //if the move direction is left 
                _moveDirection = Vector3.right; //Set the move direction to right
            else if (_moveDirection == Vector3.right) //else if move direction is right 
                _moveDirection = Vector3.left; //Set the move direction to left
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball" || collision.gameObject.tag == "Collectable")
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
    }
}
