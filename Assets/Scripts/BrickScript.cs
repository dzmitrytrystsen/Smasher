﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class BrickScript : MonoBehaviour
{
    [SerializeField] public AudioClip crackSound;
    [SerializeField] public GameObject explosionVFX;

    // Cached reference
    public LevelScript level;

    private void Start()
    {
        level = FindObjectOfType<LevelScript>(); // So after pressing Play, Engine will find and add needed object itself
        level.CountBreakableBricks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
            DestroyBlock();
    }

    public void TriggerExplosion()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }

    public void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(crackSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.SubtractBreakableBricks();
        TriggerExplosion();
    }
}
