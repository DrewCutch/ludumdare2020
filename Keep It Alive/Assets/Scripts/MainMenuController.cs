using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainScreen;

    public GameObject LevelSelectScreen;


    public void NewGame()
    {
        LevelManager.MainLevelManager.GoToNextLevel();
    }

    public void GoToMain()
    {
        MainScreen?.SetActive(true);
        LevelSelectScreen?.SetActive(false);
    }

    public void GoToLevelSelect()
    {
        MainScreen?.SetActive(false);
        LevelSelectScreen?.SetActive(true);
    }

    public void GoToSettings()
    {
        MainScreen?.SetActive(false);
        LevelSelectScreen?.SetActive(false);
    }

    public void Level1()
    {
        LevelManager.MainLevelManager.GoToLevel(1);
    }

    public void Level2()
    {
        LevelManager.MainLevelManager.GoToLevel(2);
    }

    public void Level3()
    {
        LevelManager.MainLevelManager.GoToLevel(3);
    }

    public void Level4()
    {
        LevelManager.MainLevelManager.GoToLevel(4);
    }

    public void Level5()
    {
        LevelManager.MainLevelManager.GoToLevel(5);
    }
}
