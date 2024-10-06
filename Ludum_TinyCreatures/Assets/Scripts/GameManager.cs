using System;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    StartScreen,
    GameInProgress,
    LoseGame,
    EndGame
}


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }
    
    
    [Header("Sheep")]
    [SerializeField] private int _countSheep;
    public int CountSheep { get { return _countSheep; } set { _countSheep = value; } }

    [Header("Key")]
    [SerializeField] private int _keyCount;

    public int KeyCount { get { return _keyCount; } set { _keyCount = value; } }

    [SerializeField] private int _keySecretDoorCount;
    public int KeySecretDoorCount { get { return _keySecretDoorCount; } set { _keySecretDoorCount = value; } }
    
    [Header("Timer")]
    [SerializeField] private float timer = 180;
    private float _currentTimer;

    [Header("Game State")]
    private GameState _gameState;
    public GameState GameState { get { return _gameState; } set { _gameState = value; } }
    private TimeSpan convertedTime;

    public TimeSpan ConvertedTime
    {
        get { return convertedTime; }
    }
    
    private bool letPlayerMove = false;

    public bool LetPlayerMove
    {
        get { return letPlayerMove; }
        set { letPlayerMove = value; }
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        _currentTimer = timer;
        _gameState = GameState.StartScreen;
        UIManager.Instance.LoadUI("start");
        UIManager.Instance.UnloadUI("end");
        UIManager.Instance.UnloadUI("lose");
    }

    private void Update()
    {
        switch (_gameState)
        {
            case(GameState.StartScreen):
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _gameState = GameState.GameInProgress;
                    UIManager.Instance.UnloadUI("start");
                    UIManager.Instance.LoadUI("main");
                    letPlayerMove = true;
                    UIManager.Instance.Slide("out");
                    Debug.Log("GameInProgress");
                }
                break;
            case(GameState.GameInProgress):
                GameTimer();
                ConvertTimer();
                if (_currentTimer <= 30 && _currentTimer >= 29)
                    UIManager.Instance.Slide("in");
                if (_currentTimer <= 0)
                    _gameState = GameState.LoseGame;
                break;
            case(GameState.LoseGame):
                UIManager.Instance.LoadUI("lose");
                UIManager.Instance.UnloadUI("main");
                break;
            case(GameState.EndGame):
                UIManager.Instance.LoadUI("end");
                UIManager.Instance.UnloadUI("main");
                break;
        }
    }
    
    private void GameTimer()
    {
        if (_currentTimer <= 0)
        {
            _gameState = GameState.EndGame;
            Debug.Log("End Game");
        }
        else
        {
            _currentTimer -= Time.deltaTime;
        }
    }

    private void ConvertTimer()
    {
        convertedTime = TimeSpan.FromSeconds(_currentTimer);
        Debug.Log(convertedTime.Minutes + ";" + convertedTime.Seconds);
    }
}
