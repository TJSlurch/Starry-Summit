using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPosition;
    [SerializeField] private float backgroundSpeed;
    
    // sets intial values using information from components
    void Start()
    {
        startPosition = transform.position.x;
        // length is divided by three because it is triple tiled
        length = (GetComponent<SpriteRenderer>().bounds.size.x) / 3;
    }

    // The object is moved slighyly once per frame
    void Update()
    {
        // moves the object horizontally depending on the speed attribute
        transform.position = new Vector2(transform.position.x - (backgroundSpeed/1000), transform.position.y);

        // checks if it has moved a distance of its length to the left
        if (transform.position.x < startPosition - length)
        {
            // sets the position to the original location
            transform.position = new Vector2(startPosition, transform.position.y);
        }
    }
}
