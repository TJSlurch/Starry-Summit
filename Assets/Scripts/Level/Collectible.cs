using UnityEngine;

public class Collectible : MonoBehaviour
{
    // inspector elements
    public CollectibleManager manager;
    private BoxCollider2D colliderArea;
    private SpriteRenderer image;

    [SerializeField] private int collectibleNumber;
    private bool collected = false;

    void Update()
    {
        // checking if there is a collision with the player when not collecyed
        if (collected = false && colliderArea.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Debug.Log("Collected");

            collected = true;
            // hide object
            image.enabled = false;
            // runs method in manager
            manager.newCollectible(collectibleNumber);
        }
    }

    void Start()
    {
        colliderArea = GetComponent<BoxCollider2D>();
        image = GetComponent<SpriteRenderer>();
    }
}
