using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainScreen;

    public GameObject LevelSelectScreen;

    public GameObject SettingsScreen;


    public void NewGame()
    {
        LevelManager.MainLevelManager.GoToNextLevel();
    }

    public void GoToMain()
    {
        MainScreen?.SetActive(true);
        LevelSelectScreen?.SetActive(false);
        SettingsScreen?.SetActive(false);
    }

    public void GoToLevelSelect()
    {
        MainScreen?.SetActive(false);
        LevelSelectScreen?.SetActive(true);
        SettingsScreen?.SetActive(false);
    }

    public void GoToSettings()
    {
        MainScreen?.SetActive(false);
        LevelSelectScreen?.SetActive(false);
        SettingsScreen?.SetActive(true);
    }
}
