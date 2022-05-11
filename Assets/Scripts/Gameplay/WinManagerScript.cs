using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManagerScript : MonoBehaviour
{
    [SerializeField]
    private Text _winText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            _winText.text = "YOU WIN";
        }
    }
}
