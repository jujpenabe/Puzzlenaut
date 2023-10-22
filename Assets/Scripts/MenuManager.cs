using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Handles Menu Logic an subscribe to the game manager to update the game state
    [SerializeField] private GameObject menuPanel;
    
    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    
    private void GameManagerOnGameStateChanged(GameState newState)
    {
        menuPanel.SetActive(newState == GameState.Menu);
    }
    
    public void StartGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Playing);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
