using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinManagerScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _winText; //The win Text
    [SerializeField]
    private TextMeshProUGUI _loseText;

    private void OnCollisionEnter(Collision collision)
    {
        //On collision with the player display the win text
        if (collision.gameObject.tag == "player")
        {
            _winText.text = "YOU WIN";
        }
    }

    private void Update()
    {
        if (GameManagerScript.CurrentLives <= 0)
        {
            _loseText.text = "GAME OVER";
        }
    }
}
