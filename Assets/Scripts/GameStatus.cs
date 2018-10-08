using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(1f, 3f)] [SerializeField] public float gameSpeed = 1f;

    //How to save data from the prev scene
    //But don't forget to child all text you need under GameStatus object
    //private void Awake()
    //{
    //    int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
    //    if (gameStatusCount > 1) 
    //        Destroy(gameObject);
    //    else 
    //        DontDestroyOnLoad(gameObject);
    //}

	void Start ()
	{
		
	}
	
	void Update ()
	{
	    Time.timeScale = gameSpeed;
	}
}