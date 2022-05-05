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
    public bool CanGoVertical { get { return _canGoVertical; } set { _canGoVertical = value; } }

    private void Awake()
    {
        //Get the rigidbody component
        _rigidBody = GetComponent<Rigidbody>();
        _canGoVertical = false;
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
}
