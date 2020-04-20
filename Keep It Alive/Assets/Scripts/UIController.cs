using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool Paused { get; private set; }

    public GameObject PlayOverlay;
    public GameObject PauseOverlay;

    public LevelManager LevelManager;

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
        Paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseOverlay.SetActive(false);
        PlayOverlay.SetActive(true);
        Paused = false;
    }

    public void Restart()
    {
        Resume();
        LevelManager.RestartLevel();
    }
}
