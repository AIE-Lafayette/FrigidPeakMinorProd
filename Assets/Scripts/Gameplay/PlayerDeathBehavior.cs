using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioClip _playerDeathSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball" || collision.gameObject.CompareTag("outOfBounds")) //On collision with a snowball
        {
            SoundManagerBehavior.setSoundClip(_playerDeathSound);
            SoundManagerBehavior.PlayClip = true;
            GameManagerScript.LostALife(); //Decrement player lives
            
            if(!SoundManagerBehavior.Source.isPlaying)
                SceneManagerBehavior.RestartLevel(); //Restart the level
        }
    }
}
