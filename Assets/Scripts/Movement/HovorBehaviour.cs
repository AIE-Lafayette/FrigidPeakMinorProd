using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HovorBehaviour : MonoBehaviour
{
    /// <summary>
    /// Gets the objects starting position 
    /// </summary>
    private Vector3 _startingPos;

    /// <summary>
    /// To be used for how freguwnt the bounce happens 
    /// </summary>
    [SerializeField]
    private float _frequency = 1f;

    /// <summary>
    /// Used to to set how far apart the boun
    /// </summary>
    [SerializeField]
    private float _magnitude = 1f;

    private void Start()
    {
        //sets the starting position from the starting object
        _startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        //Every frame the object postion will be changed 
        transform.position = _startingPos + transform.up * Mathf.Abs(Mathf.Sin(Time.time * _frequency)) * _magnitude;
    }
}
