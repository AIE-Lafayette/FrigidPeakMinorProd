using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public enum PlayersLiveState
{
    THREELIVES,
    TWOLIVES,
    ONELIFE,
    DEAD
}

public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _gameTimer;

    [SerializeField]
    private TextMeshProUGUI _gameScoreTest;

    [SerializeField]
    private Image _life1;
    [SerializeField]
    private Image _life2;
    [SerializeField]
    private Image _life3;


    static private PlayersLiveState _currentLives = PlayersLiveState.THREELIVES;
    static private int _collectables = 0;
    static private float _currentGameTimer = 0;
    static private float _gameScore = 0;

    /// <summary>
    /// Tracks Player Current Lives 
    /// </summary>
    static public PlayersLiveState CurrentLives { get =>_currentLives; }
    /// <summary>
    /// Tracks collectable collected 
    /// </summary>
    static public int CollectableCollected { get => _collectables;}
    /// <summary>
    /// Data Collected by deltaTime
    /// </summary>
    static public float CurrentGameTimer { get => _currentGameTimer;  }
    /// <summary>
    /// Access to the current game score current value 
    /// </summary>
    static public float GameScore { get => _gameScore; }

    //Updates Once Per Frame 
    private void Update()
    {
        _currentGameTimer += Time.deltaTime;
        TimeClock(_currentGameTimer);

        //Updates the text to the game score
        _gameScoreTest.text = GameScore.ToString();
    }

    /// <summary>
    /// Collects time On  every update Thne displays it like a time clock 
    /// </summary>
    private void TimeClock(float timeToDisplay)
    {
        timeToDisplay += 1;
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        string timer = string.Format("{0:00}:{1:00}", min, seconds);

        //Updates the test to the timer
        _gameTimer.text = timer;
    }

    /// <summary>
    /// Adds a point to the callectagble
    /// </summary>
    static public void CollectedACollectable()
    {
        _collectables++;
    }

    /// <summary>
    /// Increase the point based on the amount of pints earned 
    /// </summary>
    /// <param name="points"> Points Gained</param>
    static public void IncreaseScore(float points = 1)
    {
        _gameScore += points;
    }

    /// <summary>
    /// Removes a life from current lives
    /// </summary>
    static public void LostALife()
    {
        _currentLives--;
    }

    private void LifeState()
    {
        switch (_currentLives)
        {
            case PlayersLiveState.THREELIVES:
                break;
            case PlayersLiveState.TWOLIVES:
                break;
            case PlayersLiveState.ONELIFE:
                break;
            case PlayersLiveState.DEAD:
                break;
        }

    }
}



