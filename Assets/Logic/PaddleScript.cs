﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] public float minScreenSizeInUnits = 1f;
    [SerializeField] public float maxScreenSizeInUnits = 15f;

    public float mousePos;

	void Start ()
    {
		
	}
	
	void Update ()
	{
		mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
	    paddlePos.x = Mathf.Clamp(mousePos, minScreenSizeInUnits, maxScreenSizeInUnits);
	    transform.position = paddlePos;
	}
}
