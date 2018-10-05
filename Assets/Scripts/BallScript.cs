using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public PaddleScript paddle;
    [SerializeField] public float bounceBallX = -2f;
    [SerializeField] public float bounceBallY = 15f;
    [SerializeField] public AudioClip[] fireballSounds;

    public Vector2 paddleToBallVector;
    public bool hasStarted = false;

    // Cached components references
    public AudioSource myAudioSource;

    void Start ()
    {
        paddleToBallVector = transform.position;
        myAudioSource = GetComponent<AudioSource>();
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clips = fireballSounds[Random.Range(0, fireballSounds.Length)];
            myAudioSource.PlayOneShot(clips);
        }
    }
}
