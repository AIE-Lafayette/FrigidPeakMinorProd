using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincabilityBehaviour : MonoBehaviour
{
    private MeshRenderer _mashRender;
    private Color _color;

    private PlayerMovementBehavior _movement;
    private float _startingSpeed;

    private RoutineBehaviour.TimedAction _routune;

    [SerializeField]
    private float _invincibleTime = 3f;
    [SerializeField]
    private int _speedMultiplyer = 2;

    // Start is called before the first frame update
    void Start()
    {
        _mashRender = GetComponent<MeshRenderer>();
        _movement = GetComponent<PlayerMovementBehavior>();

        _startingSpeed = _movement.Speed;
        _color = _mashRender.material.color;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("Collectable"))
            GetInvuerable();
    }

    public void GetInvuerable()
    {
        Physics.IgnoreLayerCollision(6, 8, true);
        _color.a = .3f;
        _mashRender.material.color = _color;
        Debug.Log("Aactive");

        _movement.Speed = _startingSpeed * _speedMultiplyer;
        _routune = RoutineBehaviour.Instance.StartNewTimedAction(args => RemoveInurability(), TimedActionCountType.SCALEDTIME, 7f);
    }

    public void RemoveInurability()
    {
        Debug.Log("Disactivated");
        Physics.IgnoreLayerCollision(6, 8, false);
        _color.a = 1;
        _mashRender.material.color = _color;
        _movement.Speed = _startingSpeed;
    }
}