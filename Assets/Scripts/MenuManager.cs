using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Handles Menu Logic an subscribe to the game manager to update the game state
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject creditsPanel;
    
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
    
    public void ShowCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void HideCredits()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        // Wait for 1 second before quitting the game
        StartCoroutine(QuitGameAfterDelay(2f));
        
    }
    
    private IEnumerator QuitGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
