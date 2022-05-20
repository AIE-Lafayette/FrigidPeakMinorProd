using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _winScreen; //The win Text

    private void OnCollisionEnter(Collision collision)
    {
        //On collision with the player display the win text
        if (collision.gameObject.tag == "player")
        {
            _winScreen.SetActive(true);
        }
    }

    private void Update()
    {
        if (GameManagerScript.CurrentLives <= 0)
        {
            _winScreen.SetActive(true);
        }
    }
}
