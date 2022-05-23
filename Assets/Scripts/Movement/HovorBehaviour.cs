using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HovorBehaviour : MonoBehaviour
{
    //Gets 
    private Vector3 _startingPos;

    [SerializeField]
    private float _frequency = 5f;

    [SerializeField]
    private float _magnitude = 5f;

    private void Start()
    {
        _startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = _startingPos + transform.up * Mathf.Sin(Time.time * _frequency) * _magnitude;
    }
}
