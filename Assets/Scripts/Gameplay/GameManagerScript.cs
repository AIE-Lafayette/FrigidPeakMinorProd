using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private Text _gameTimer;

    static private int _currentLives = 3;
    static private int _clectables = 0;
    static private float _currentGameTimer = 0;
    static private float _gameScore = 0;

    //Tracks Player Current Lives 
    static public int CurrentLives { get { return _currentLives; } set { _currentLives = value; } }
    //Trackscollectable collected 
    static public int Celectables { get { return _clectables; } set { _clectables = value; } }
    static public float CurrentGameTimer { get { return _currentGameTimer; } }
    static public float GameScore { get { return _gameScore; } set { _gameScore = value; } }

    private void Start()
    {
        _currentGameTimer += 1 + Time.deltaTime; 
    }

    private void Update()
    {
        TimeClock();
    }


    private void TimeClock()
    {    
        float milaSeconds = Mathf.FloorToInt(_currentGameTimer % 60);
        float seconds = Mathf.FloorToInt(_currentGameTimer / 60);
        float min = Mathf.FloorToInt(seconds / 60);
        string timer = string.Format("{0:00}:{1:00}" , min, seconds);
        _gameTimer.text = timer;
    }
}

