using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public PaddleScript paddle;
    [SerializeField] public float bounceBallX = -2f;
    [SerializeField] public float bounceBallY = 15f;

    public Vector2 paddleToBallVector;
    public bool hasStarted = false;


    void Start ()
    {
        paddleToBallVector = transform.position;
    }
	
	void Update ()
    {
        if (!hasStarted)
        {
            BallToPaddle();
            BounceTheBall();
        }
    }

    public void BallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, transform.position.y);
        transform.position = paddlePos;
    }

    public void BounceTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(bounceBallX, bounceBallY);
            hasStarted = true;
        }
    }
}
