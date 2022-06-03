using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball" || collision.gameObject.CompareTag("outOfBounds")) //On collision with a snowball
        {
            GameManagerScript.LostALife(); //Decrement player lives
            SceneManagerBehavior.RestartLevel(); //Restart the level
        }
    }
}
