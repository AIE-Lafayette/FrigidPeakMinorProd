using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinManagerScript : MonoBehaviour
{
    [SerializeField]
    private Text _winText; //The win Text

    private void OnCollisionEnter(Collision collision)
    {
        //On collision with the player display the win text
        if (collision.gameObject.tag == "player")
        {
            _winText.text = "YOU WIN";
        }
    }
}
