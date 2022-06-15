using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreenTextBehavior : MonoBehaviour
{
    //[SerializeField]
    //private TextMeshProUGUI _winLoseMessage; //The win/lose text
    [SerializeField]
    private TextMeshProUGUI _endScore; //The text that displays your end score

    private void Update()
    {
        //if (GameManagerScript.CurrentLives > 0) //If the game ends and your lives are greater than 0 display You Win
        //    _winLoseMessage.text = "You Win!";
        //else if (GameManagerScript.CurrentLives <= 0) //if the game ends and your lives are less than or equal to 0 display game over
        //    _winLoseMessage.text = "Game Over";

        _endScore.text = $"Score: {GameManagerScript.GameScore}"; //Display your current score
    }
}
