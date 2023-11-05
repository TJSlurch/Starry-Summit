using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private int screenNumber; 
    private float xPos;
    private float yPos;

    private BoxCollider2D colliderArea;
    public PlayerLocationTracker tracker;

    // uses the object's transform component to find initial position
    void Start()
    {
        colliderArea = GetComponent<BoxCollider2D>();
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    void Update()
    {
        // checks for a request, or if this collider is currently active
        if(tracker.GetScreenRequest() == true || tracker.getScreen() == screenNumber)
        {
            // detects if the player is touching the collider
            if (colliderArea.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                // updates screen number, coordinates and request
                tracker.setScreen(screenNumber);
                tracker.setScreenRequest(false);
                tracker.setScreenX(xPos);
                tracker.setScreenY(yPos);
            }
            else
            {
                // collider is no longer active so a new one is requested
                tracker.setScreenRequest(true);
            }
        }
    }
}
