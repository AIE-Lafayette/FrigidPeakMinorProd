using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDespawnBehavior : MonoBehaviour
{
    private float _currentLife; //How long the snowball has existed 
    [SerializeField]
    private float _lifetime = 10.0f; //How lonf the snowball can exist

    private void Update()
    {
        _currentLife += Time.deltaTime;

        if (_currentLife >= _lifetime) //If the current lif is greater than its lifetime destroy object
            Destroy(gameObject);
    }
}
