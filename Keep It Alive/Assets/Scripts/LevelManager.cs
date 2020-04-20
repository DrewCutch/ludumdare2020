using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public String[] Levels;

    public int CurrentLevelI { get; private set; }

    public static LevelManager MainLevelManager;

    public void Awake()
    {
        if (MainLevelManager != null)
        {
            Destroy(gameObject);
            return;
        }

        GameObject.DontDestroyOnLoad(gameObject);

        MainLevelManager = this;
        CurrentLevelI = Levels.ToList().IndexOf(SceneManager.GetActiveScene().name);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(Levels[CurrentLevelI]);
    }

    public void GoToNextLevel()
    {
        CurrentLevelI = (CurrentLevelI + 1) % Levels.Length;
        RestartLevel();
    }

    public void GoToMainMenu()
    {
        CurrentLevelI = 0;
        RestartLevel();
    }
}
