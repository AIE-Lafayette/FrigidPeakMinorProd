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

    // Death pushback
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _pushbackForce = 5.0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball" || collision.gameObject.CompareTag("outOfBounds")) //On collision with a snowball
        {
            _rigidbody.AddForce(-Vector3.forward * _pushbackForce, ForceMode.Impulse);
            _deathSoundSource.Play();
            GameManagerScript.LostALife(); //Decrement player lives
            _currentAction = RoutineBehaviour.Instance.StartNewTimedAction(args => SceneManagerBehavior.RestartLevel(), TimedActionCountType.SCALEDTIME, _waitTime);
            /*SceneManagerBehavior.RestartLevel();*/ //Restart the level
        }
    }
}
