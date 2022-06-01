using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerCollisionBehaviour : MonoBehaviour
{
    [SerializeField]
   //This Game Objects Point Worth 
    private float _pointsWorth = 0f;

    //Checks the cllision on the other Game object 
    private void OnCollisionEnter(Collision collision)
    {

        //If the other collider is of that of the 'player'
        if (collision.other.CompareTag("player"))
        {
            //The game manager will add the points earned to the game manager
            GameManagerScript.IncreaseScore(_pointsWorth);
            //Debug message to let me know if it has collided
            Debug.LogWarning("Object Collided");
            //Destroys this game object
            Destroy(gameObject);
        }
    }
}
