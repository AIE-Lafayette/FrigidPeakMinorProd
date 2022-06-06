using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeBehavior : MonoBehaviour
{
    private bool _canShake;

    [SerializeField]
    private float _shakeDuration = 2.0f;
    [SerializeField]
    private float _shakeAmount = 0.5f;
    private float _timer = 0f;
    private Vector3 _originalPos;

    public bool CanShake { get { return _canShake; } set { _canShake = value; } }

    private void OnEnable()
    {
        _originalPos = transform.position;

        //FOR TESTING PURPOSES ONLY DO NOT UNCOMMENT
        //CanShake = true;
    }

    private void Update()
    {
        if (CanShake)
        {
            if (_timer < _shakeDuration)
            {
                //Shake the camera by adding 
                transform.position = _originalPos + Random.insideUnitSphere * _shakeAmount;
                _timer += Time.deltaTime;
            }
            else
            {
                //Set CanShake to false
                _canShake = false;

                //Set timer to 0
                _timer = 0f;
            }
        }
    }
}
