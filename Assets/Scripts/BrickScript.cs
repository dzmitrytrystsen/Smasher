using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] public AudioClip crackSound;

    // Cached reference
    public LevelScript level;

    private void Start()
    {
        level = FindObjectOfType<LevelScript>(); // So after pressing Play, Engine will find and add needed object itself
        level.CountBreakableBricks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crackSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.SubtractBreakableBricks();
    }
}
