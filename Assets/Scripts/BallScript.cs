using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public PaddleScript paddle;
    public Vector2 paddleToBallVector;

    void Start ()
    {
        paddleToBallVector = transform.position;
    }
	
	void Update ()
	{
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, transform.position.y);
	    transform.position = paddlePos;
	}
}
