using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 _velocity;
    [SerializeField]
    private Vector3 _moveDirection = Vector3.left;
    private bool _isGrounded;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Vector3 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    private void Update()
    {
        if (_isGrounded)
        {
            //Vector3 direction = Vector3.left;
            Velocity = _moveDirection.normalized * Speed;
            transform.position += Velocity * Time.deltaTime;
        } 
    }

    private void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrier")
        {
            if (_moveDirection == Vector3.left)
                _moveDirection = Vector3.right;
            else if (_moveDirection == Vector3.right)
                _moveDirection = Vector3.left;
        }
    }
}
