using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRotationBehaviour : MonoBehaviour
{
    [SerializeField]
    float _speed = 200;
    // Update is called once per frame
    void Update()
    {
        //Changes the rotation of the gameobjects transform 
        transform.Rotate(0, Mathf.Sin(Time.deltaTime * _speed * 3), Mathf.Tan(Time.deltaTime * _speed) * 3);
    }
}
