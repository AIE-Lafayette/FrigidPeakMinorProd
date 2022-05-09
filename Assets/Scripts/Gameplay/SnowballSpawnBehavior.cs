using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawnBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _snowball; //The snowball to clone and spawn
    [SerializeField]
    private float _cooldown; //Cooldown between spawns
    private float _spawnTime = 0.0f;

    private void Update()
    {
        if (_spawnTime >= _cooldown) //If spawn time is greater than the cooldown
        {
            GameObject spawnedObject = Instantiate(_snowball, transform.position, transform.rotation); //Instantiate the snowballs 
            _spawnTime = 0.0f;
        }
        _spawnTime += Time.deltaTime;
    }
}
