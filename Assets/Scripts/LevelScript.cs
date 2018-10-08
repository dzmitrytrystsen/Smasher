﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    [SerializeField] public int breakableBricks;
    [SerializeField] public Text BricksCounterText;

    //Cached reference
    public SceneLoaderScript sceneLoader;

    public void Update()
    {
        BricksCounterText.text = ("Briks left: " + breakableBricks);
    }

    public void CountBreakableBricks()
    {
        breakableBricks++;
    }

    public void SubtractBreakableBricks()
    {
        breakableBricks--;

        if (breakableBricks <= 0)
            sceneLoader.LoadNextScene();
    }
}
