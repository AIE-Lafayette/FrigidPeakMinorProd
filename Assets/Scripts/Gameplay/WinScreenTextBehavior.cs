using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreenTextBehavior : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _winLoseMessage;
    [SerializeField]
    private TextMeshProUGUI _endScore;

    private void Update()
    {
        if (GameManagerScript.CurrentLives > 0)
            _winLoseMessage.text = "You Win!";
        else if (GameManagerScript.CurrentLives <= 0)
            _winLoseMessage.text = "Game Over";

        _endScore.text = $"Score: {GameManagerScript.GameScore}";
    }
}
