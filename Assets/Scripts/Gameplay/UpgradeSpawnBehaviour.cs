using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _upgrades;

    //Time till next upgrade
    [SerializeField]
    private float _cooldown;
    //The Count Down to the the next spawn
    private float _spawnTimer;

    // Update is called once per frame
    void Update()
    {
        //Creates clone of the game objects 
        if (_spawnTimer >= _cooldown)
        {
            Instantiate(_upgrades, transform.position , Quaternion.identity);
            _spawnTimer = 0;
        }
        _spawnTimer += Time.deltaTime;

    }
}
