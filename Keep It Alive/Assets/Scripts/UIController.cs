using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool Paused { get; private set; }

    public GameObject PlayOverlay;
    public GameObject PauseOverlay;
    public GameObject GameOverOverlay;

    public void TogglePause()
    {
        if (Paused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseOverlay.SetActive(true);
        PlayOverlay.SetActive(false);
        GameOverOverlay.SetActive(false);
        Paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseOverlay.SetActive(false);
        PlayOverlay.SetActive(true);
        GameOverOverlay.SetActive(false);
        Paused = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        PauseOverlay.SetActive(false);
        PlayOverlay.SetActive(false);
        GameOverOverlay.SetActive(true);
        Paused = true;
    }

    public void Restart()
    {
        Resume();
        LevelManager.MainLevelManager.RestartLevel();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        LevelManager.MainLevelManager.GoToMainMenu();
    }
}
