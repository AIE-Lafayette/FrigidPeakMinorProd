using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBehaviour : MonoBehaviour
{
    private Vector3 _startPosition;

    
    [SerializeField]
    private float _frequency = 5f;
    [SerializeField]
    //The distance between 
    private float _magnitude = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Sets to move a game object at in a up and down motion
        transform.position = _startPosition + transform.up * Mathf.Sin(Time.time * _frequency) * _magnitude;
    }
}
