using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] public AudioClip crackSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crackSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
