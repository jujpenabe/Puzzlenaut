using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game Manager to control the game state
    
    public static GameManager Instance;
    
    public GameState State;

    public static event Action<GameState> OnGameStateChanged; 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
            UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (State)
        {
            case GameState.Menu:
                break;
            case GameState.Playing:
                HandlePlayingState();
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        
        OnGameStateChanged?.Invoke(State);
        
    }

    private void HandlePlayingState()
    {

    }

}

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver
} 
