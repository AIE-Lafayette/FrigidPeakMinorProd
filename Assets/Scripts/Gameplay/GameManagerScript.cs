using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    private Text _gameTimer;

    [SerializeField]
    private Text _gameScoreTest;

    static private int _currentLives = 3;
    static private int _collectables = 0;
    static private float _currentGameTimer = 0;
    static private float _gameScore = 0;

    /// <summary>
    /// Tracks Player Current Lives 
    /// </summary>
    static public int CurrentLives { get { return _currentLives; } }
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
        TimeClock();
        _gameScoreTest.text = GameScore.ToString();

    }

    /// <summary>
    /// Collects time On  every update Thne displays it like a time clock 
    /// </summary>
    private void TimeClock()
    {
        _currentGameTimer += 1 + Time.deltaTime;
        float milaSeconds = Mathf.FloorToInt(_currentGameTimer / 60);
        float seconds = Mathf.FloorToInt(milaSeconds % 60);
        float min = Mathf.FloorToInt(milaSeconds / 60);
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

