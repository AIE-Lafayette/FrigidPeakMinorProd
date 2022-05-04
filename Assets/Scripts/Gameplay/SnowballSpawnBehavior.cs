using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawnBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _snowball;
    [SerializeField]
    private float _cooldown;
    private float _spawnTime = 0.0f;

    private void Update()
    {
        if (_spawnTime >= _cooldown)
        {
            GameObject spawnedObject = Instantiate(_snowball, transform.position, transform.rotation);
            _spawnTime = 0.0f;
        }
        _spawnTime += Time.deltaTime;
    }
}
