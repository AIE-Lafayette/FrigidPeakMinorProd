using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private Text _gameTimer;

    static private int _currentLives = 3;
    static private int _collectables = 0;
    static private float _currentGameTimer = 0;
    static private float _gameScore = 0;

    //Tracks Player Current Lives 
    static public int CurrentLives { get { return _currentLives; } }
    //Tracks collectable collected 
    static public int Collectables { get { return _collectables; } }

    static public float CurrentGameTimer { get { return _currentGameTimer; } }
    static public float GameScore { get { return _gameScore; } }

    private void Start()
    {

    }

    private void Update()
    {
        TimeClock();
    }


    private void TimeClock()
    {
        _currentGameTimer += 1 + Time.deltaTime;
        float milaSeconds = Mathf.FloorToInt(_currentGameTimer / 60);
        float seconds = Mathf.FloorToInt(milaSeconds % 60);
        float min = Mathf.FloorToInt(milaSeconds / 60);
        string timer = string.Format("{0:00}:{1:00}" , min, seconds);
        _gameTimer.text = timer;
    }

    //Adds a point to the callectagble
    static public void CollectedACollectable()
    {
        _collectables++;
    }

    //Increase the point based on the amount of pints earned 
    static public void IncreaseScore(float points = 1)
    {
        _gameScore += points;
    }

    //Removes a life from current lives 
    static public void LostALife()
    {
        _currentLives--;
    }
}

