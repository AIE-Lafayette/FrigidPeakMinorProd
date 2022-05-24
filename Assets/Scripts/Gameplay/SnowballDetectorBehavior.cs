using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDetectorBehavior : MonoBehaviour
{
    private Vector3 _rayDir;
    private Ray _detector;

    private void Awake()
    {
        _rayDir = -transform.up * 100;
        _detector = new Ray(transform.position, _rayDir);
    }

    private void FixedUpdate()
    {
        RaycastHit hitData;
        Physics.Raycast(_detector, out hitData);

        if (hitData.collider.tag == "snowball")
        {
            Debug.Log("There was a hit, score should increase");
            GameManagerScript.IncreaseScore();
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 rayDir  = -transform.up * 100;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, rayDir);
    }
}
