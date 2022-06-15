using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public delegate void Event();

public class PlayerDeathBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioSource _deathSoundSource;
    private RoutineBehaviour.TimedAction _currentAction;
    [SerializeField]
    private float _waitTime = 5;
    private Event _onDeath;

    public Event OnDeath { get => _onDeath; set => _onDeath = value; }

    // Death pushback
    private Rigidbody _rigidbody;
    private InputDelegateBehavior _inputBehavior;
    [SerializeField]
    private float _pushbackForce = 5.0f;
    private Vector3 _pushbackDistance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputBehavior = GetComponent<InputDelegateBehavior>();
        _onDeath += () => _deathSoundSource.Play();
        _onDeath += () => GameManagerScript.LostALife();
        _onDeath += () => _inputBehavior.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball" || collision.gameObject.CompareTag("outOfBounds")) //On collision with a snowball
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _rigidbody.AddForce(Vector3.back * _pushbackForce, ForceMode.Impulse);
            _onDeath?.Invoke();
            _currentAction = RoutineBehaviour.Instance.StartNewTimedAction(args => SceneManagerBehavior.RestartLevel(), TimedActionCountType.SCALEDTIME, _waitTime);
        }
    }
}

           