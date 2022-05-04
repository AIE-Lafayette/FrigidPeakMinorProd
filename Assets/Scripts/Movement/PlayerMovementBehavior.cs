using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidBody;
    private Vector3 _moveDir;
    private bool _canGoVertical;

    public Vector3 MoveDirection { get { return _moveDir; } set { _moveDir = value; } }

    private void Awake()
    {
        //Get the rigidbody component
        _rigidBody = GetComponent<Rigidbody>();
        _canGoVertical = false;
    }

    private void FixedUpdate()
    {
        if (_canGoVertical)
        {

        }

        // Set the velocity
        Vector3 velocity = MoveDirection * _speed * Time.deltaTime;

        // Move The position of the rigidbody
        _rigidBody.MovePosition(transform.position + velocity);
    }
}
