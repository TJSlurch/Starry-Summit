using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPosition;
    public float backgroundSpeed;
    
    // sets intial values using information from components
    void Start()
    {
        startPosition = transform.position.x;
        // length is divided by three because it is triple tiled
        length = (GetComponent<SpriteRenderer>().bounds.size.x) / 3;
    }

    // Update is called once per frame
    void Update()
    {
        // moves the object in the opposite direction to the player velocity
        transform.position = new Vector2(transform.position.x - (backgroundSpeed/1000), transform.position.y);

        // checks if it has moved (a third of) its length left
        if (transform.position.x < startPosition - length)
        {
            // sets the position to the original location
            transform.position = new Vector2(startPosition, transform.position.y);
        }
    }
}
