using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRotationBehaviour : MonoBehaviour
{
    [SerializeField]
    float _speed = 10;
    // Update is called once per frame
    void Update()
    {
        //Changes the rotation of the gameobjects transform 
        transform.Rotate(0, (Time.deltaTime * _speed * 3), 0);
    }
}
