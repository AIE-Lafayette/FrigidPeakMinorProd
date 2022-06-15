using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincabilityBehaviour : MonoBehaviour
{
    /// <summary>
    /// Handles this objects mesh render
    /// </summary>
    [SerializeField]
    private SkinnedMeshRenderer _mashRender;
    
    /// <summary>
    /// Holds the color of this object 
    /// </summary>
    private Material _startingMaterial;

    /// <summary>
    /// Gets a refrence of the routine behaviour
    /// </summary>
    private RoutineBehaviour.TimedAction _routune;

    /// <summary>
    /// Sets timer for inbetween invinvability
    /// </summary>
    [SerializeField]
    private float _invincibleTime = 3f;

    [SerializeField]
    private Material _goldMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _startingMaterial = _mashRender.material;
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
        _mashRender.material = _goldMaterial;
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
        _mashRender.material = _startingMaterial;
    }
}
