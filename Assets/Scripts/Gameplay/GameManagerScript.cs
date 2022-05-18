using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _gameTimer;

    [SerializeField]
    private TextMeshProUGUI _gameScoreTest;

    static private int _currentLives = 3;
    static private int _collectables = 0;
    static private float _currentGameTimer = 0;
    static private float _gameScore = 0;

    /// <summary>
    /// Tracks Player Current Lives 
    /// </summary>
    static public int CurrentLives { get { return _currentLives; } set { _currentLives = value; } }
    /// <summary>
    /// Tracks collectable collected 
    /// </summary>
    static public int CollectableCollected { get { return _collectables; } }
    /// <summary>
    /// Data Collected by deltaTime
    /// </summary>
    static public float CurrentGameTimer { get { return _currentGameTimer; } }
    /// <summary>
    /// Access to the current game score current value 
    /// </summary>
    static public float GameScore { get { return _gameScore; } }

    //Updates Once Per Frame 
    private void Update()
    {
        _currentGameTimer += Time.deltaTime;
        TimeClock(_currentGameTimer);
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
}

