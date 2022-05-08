using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDespawnBehavior : MonoBehaviour
{
    private float _currentLife;
    [SerializeField]
    private float _lifetime = 10.0f;

    private void Update()
    {
        _currentLife += Time.deltaTime;

        if (_currentLife >= _lifetime)
            Destroy(gameObject);
    }
}
