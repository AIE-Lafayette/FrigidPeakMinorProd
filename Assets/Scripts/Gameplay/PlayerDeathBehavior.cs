using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioSource _deathSoundSource;
    private RoutineBehaviour.TimedAction _currentAction;
    [SerializeField]
    private float _waitTime = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball" || collision.gameObject.CompareTag("outOfBounds")) //On collision with a snowball
        {
            _isAlive = false;
            _deathSoundSource.Play();
            GameManagerScript.LostALife(); //Decrement player lives
            _currentAction = RoutineBehaviour.Instance.StartNewTimedAction(args => SceneManagerBehavior.RestartLevel(), TimedActionCountType.SCALEDTIME, _waitTime);
            /*SceneManagerBehavior.RestartLevel();*/ //Restart the level
        }
    }
}
