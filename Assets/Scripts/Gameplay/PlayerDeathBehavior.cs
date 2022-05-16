using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball")
        {
            GameManagerScript.CurrentLives--;
            SceneManagerBehavior.RestartLevel();
        }
    }
}
