using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelAdvancer : MonoBehaviour
{
    public void AdvanceLevel()
    {
        LevelManager.MainLevelManager.GoToNextLevel();
    }
}
