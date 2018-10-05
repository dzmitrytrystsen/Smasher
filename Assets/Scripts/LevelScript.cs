using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] public int breakableBricks;

    //Cached reference
    public SceneLoaderScript sceneLoader;

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
