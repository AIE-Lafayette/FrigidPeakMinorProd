using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliberStateMachineBehavior : MonoBehaviour
{
    [SerializeField]
    private Material[] _material;
    [SerializeField]
    private SkinnedMeshRenderer _playerMesh;

    private Material _startingMaterial;

   

    void Update()
    {

        switch (GameManagerScript.CurrentLives)
        {
            case PlayersLiveState.FOURTHLIVES:
                _playerMesh.material = _material[0];
                break;
            case PlayersLiveState.THREELIVES:
                _playerMesh.material = _material[1];
                break;
            case PlayersLiveState.TWOLIVES:
                _playerMesh.material = _material[2];
                break;
            case PlayersLiveState.ONELIFE:
                _playerMesh.material = _material[3];
                break;
            default:
                _playerMesh.material = _material[0];
                break;
        }
    }
}
