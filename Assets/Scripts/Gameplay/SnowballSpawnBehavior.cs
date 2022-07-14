using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawnBehavior : MonoBehaviour
{
    [SerializeField]
    private SnowballMovementBehavior _snowball; //The snowball to clone and spawn
    [SerializeField]
    private float _cooldown; //Cooldown between spawns
    private float _spawnTime = 0.0f;
    [SerializeField]
    private GameObject _player;
    private bool _direction = true; //For refrence to where the snowball directing

    public bool Direction { get => _direction; }

    private void Update()
    {
        if (_spawnTime >= _cooldown) //If spawn time is greater than the cooldown
        {
            SnowballMovementBehavior spawnedObject = Instantiate(_snowball, transform.position, transform.rotation); //Instantiate the snowballs 
            _spawnTime = 0.0f;

            if (_player.transform.position.x < transform.position.x)
            {
                spawnedObject.MovesLeft = true;
                _direction = true;
            }
            else if (_player.transform.position.x > transform.position.x)
            {
                spawnedObject.MovesLeft = false;

                _direction = false;
            }
        }
        _spawnTime += Time.deltaTime;
    }
}
