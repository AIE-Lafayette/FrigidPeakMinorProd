using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincabilityBehaviour : MonoBehaviour
{
    /// <summary>
    /// Handles this objects mesh render
    /// </summary>
    private MeshRenderer _mashRender;
    
    /// <summary>
    /// Holds the color of this object 
    /// </summary>
    private Color _color;

    /// <summary>
    /// Gets a refrence of the routine behaviour
    /// </summary>
    private RoutineBehaviour.TimedAction _routune;

    /// <summary>
    /// Sets timer for inbetween invinvability
    /// </summary>
    [SerializeField]
    private float _invincibleTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _mashRender = GetComponent<MeshRenderer>();

        _color = _mashRender.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("PickAxeUpgrade"))
            GetInvulnerability();
    }

    /// <summary>
    /// Gives the illusion of invulnerability to a game object attached to this script 
    /// </summary>
    public void GetInvulnerability()
    {
        Physics.IgnoreLayerCollision(6, 8, true);
        _color.a = .3f;
        _mashRender.material.color = _color;
        Debug.Log("Aactive");

        _routune = RoutineBehaviour.Instance.StartNewTimedAction(args => RemoveInvulnerability(), TimedActionCountType.SCALEDTIME, 7f);
    }

    /// <summary>
    /// Disactivates the ability of invulnerability
    /// </summary>
    public void RemoveInvulnerability()
    {
        Debug.Log("Disactivated");
        Physics.IgnoreLayerCollision(6, 8, false);
        _color.a = 1;
        _mashRender.material.color = _color;
    }
}
