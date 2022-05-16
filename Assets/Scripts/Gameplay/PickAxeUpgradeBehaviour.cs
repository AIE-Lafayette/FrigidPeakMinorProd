using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeUpgradeBehaviour : MonoBehaviour
{
    private PlayerMovementBehavior _movement;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
            _movement = collision.collider.GetComponent<PlayerMovementBehavior>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncreasePlayerMovemnet()
    {
        if(_movement)
            _movement.
    } 
}
