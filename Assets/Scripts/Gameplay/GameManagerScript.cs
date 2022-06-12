using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public enum PlayersLiveState
{
    DEAD,
    ONELIFE,
    TWOLIVES,
    THREELIVES
}


public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _gameTimer;

    [SerializeField]
    private TextMeshProUGUI _gameScoreTest;

    [SerializeField]
    private TextMeshProUGUI _displayHighscore;

    [SerializeField]
    private Image _life1;
    [SerializeField]
    private Image _life2;
    [SerializeField]
    private Image _life3;

    //private LoadAndSaveScript _saveFile = new LoadAndSaveScript("ScoreBoard.txt");

    static private Highscore _highscore = new Highscore(29032, "ScoreBoard.txt");


    static private PlayersLiveState _currentLives = PlayersLiveState.ONELIFE;
    static private int _collectables = 0;
    static private float _currentGameTimer = 0;
    static private float _gameScore = 0;


    static bool _isAlive = true;

    /// <summary>
    /// Tracks Player Current Lives 
    /// </summary>
    static public PlayersLiveState CurrentLives { get => _currentLives; }
    /// <summary>
    /// Tracks collectable collected 
    /// </summary>
    static public int CollectableCollected { get => _collectables; }
    /// <summary>
    /// Data Collected by deltaTime
    /// </summary>
    static public float CurrentGameTimer { get => _currentGameTimer; }
    /// <summary>
    /// Access to the current game score current value 
    /// </summary>
    static public float GameScore { get => _gameScore; }

    //Plyer death State
    static public bool  IsAlive { get => _isAlive; }

    private void Awake()
    {
        //if (!_saveFile.Load())
        //    Debug.Log("LoadFailed");

        //_highscore = _saveFile.HighScore();
    }

    //Updates Once Per Frame 
    private void Update()
    {
        LifeState();

        _currentGameTimer += Time.deltaTime;
        TimeClock(_currentGameTimer);


        _displayHighscore.text = _highscore.CurrentHighscore.ToString();

        //Updates the text to the game score
        _gameScoreTest.text = _gameScore.ToString();
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

    /// <summary>
    /// ReInizalizes the current values to be that of the defulted values
    /// </summary>
    static public void Reinitialize()
    {
        _currentLives = PlayersLiveState.THREELIVES;
        _collectables = 0;
        _currentGameTimer = 0;
        _gameScore = 0;

        _isAlive = true;
    }

    // Was a save file for the player to save there progress 
    //public void Save(string name)
    //{
    //    name.ToUpper();

    //    _saveFile.AddScore(name,GameScore);
    //    _saveFile.Save();
    //}

    /// <summary>
    /// Player life states 
    /// </summary>
    private void LifeState()
    {
        switch (_currentLives)
        {
            case PlayersLiveState.THREELIVES:
                _life1.enabled = true;
                _life2.enabled = true;
                _life3.enabled = true;
                break;
            case PlayersLiveState.TWOLIVES:
                _life1.enabled = true;
                _life2.enabled = true;
                _life3.enabled = false;
                break;
            case PlayersLiveState.ONELIFE:
                _life1.enabled = true;
                _life2.enabled = false;
                _life3.enabled = false;
                break;
            case PlayersLiveState.DEAD:
                _life1.enabled = false;
                _life2.enabled = false;
                _life3.enabled = false;
                _highscore.Save();
                _highscore.NewScore((int)_gameScore);
                _isAlive = false;
                break;
        }

    }
}



