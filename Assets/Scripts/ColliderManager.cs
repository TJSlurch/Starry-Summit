using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    public int screenNumber; 
    private float xPos;
    private float yPos;

    private BoxCollider2D colliderArea;
    public PlayerLocationTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        colliderArea = GetComponent<BoxCollider2D>();
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(tracker.GetScreenRequest() == true || tracker.getScreen() == screenNumber)
        {
            if (colliderArea.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                tracker.setScreen(screenNumber);
                tracker.setScreenRequest(false);
                tracker.setScreenX(xPos);
                tracker.setScreenY(yPos);
            }
            else
            {
                tracker.setScreenRequest(true);
            }
        }
    }

    public float getcolliderX()
    {
        return xPos;
    }

    public float getcolliderY()
    {
        return yPos;
    }

}
