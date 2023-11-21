using UnityEngine;

public class Collectible : MonoBehaviour
{
    // inspector elements
    [SerializeField] private CollectibleManager manager;
    private SpriteRenderer image;
    private ParticleSystem particles;

    [SerializeField] private int collectibleNumber;
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ensures is hasn't been collected yet
        if (!collected)
        {
            //prevents it from being collected again
            collected = true;
            // hide object and particles
            image.enabled = false;
            particles.Stop();
            // informs manager script of collection
            StartCoroutine(manager.newCollectible(collectibleNumber));
        }
    }
   
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        particles = GetComponent<ParticleSystem>();
    }
}
