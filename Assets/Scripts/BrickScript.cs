using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] public AudioClip crackSound;
    [SerializeField] public GameObject explosionVFX;
    [SerializeField] public Sprite[] damageSprite;

    // Cached reference
    public LevelScript level;

    //state variables
    [SerializeField] public int timesHit;

    private void Start()
    {
            level.CountBreakableBricks();
            level = FindObjectOfType<LevelScript>(); // So after pressing Play, Engine will find and add needed object itself
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        HitsLogic();
    }

    public void HitsLogic()
    {
        timesHit++;
        int maxHits = damageSprite.Length + 1;


        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }

        else
        {
            ShowNextSprite();
        }

    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;

        if (damageSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageSprite[spriteIndex];
        }

        else
        {
            Debug.LogError("Brick sprite is missing" + gameObject.name);
        }
    }

    public void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(crackSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.SubtractBreakableBricks();
        TriggerExplosion();
    }

    public void TriggerExplosion()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
