using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatforms : MonoBehaviour
{
    [SerializeField] private float speed; // the speed of falling
    [SerializeField] private float respawnTime; // the time taken to respawn
    private float startPosition; // the initial position
    private bool falling; // whether or not the object is falling

    private void Start()
    {
        startPosition = transform.position.y; // sets the platform's initial position
    }
    private void FixedUpdate()
    {
        if (falling) // constantly falls if bool is true
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 10), speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) // when a player lands on the platform
    {
        if(!falling)
            StartCoroutine(respawnPlatform());
        falling = true;
    }

    private IEnumerator respawnPlatform() 
    {
        yield return new WaitForSeconds(respawnTime); // waits desired time
        falling = false; // stops the object falling
        transform.position = new Vector2(transform.position.x, startPosition); // sets position at the top again
    }
}
