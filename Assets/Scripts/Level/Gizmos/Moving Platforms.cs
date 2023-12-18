using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private bool axisOfMovement; // true = x axis, false = y axis
    [SerializeField] private float minCoordinate; // the minimum coordinate
    [SerializeField] private float maxCoordinate; // the maximum coordinate
    [SerializeField] private float speed; // the speed of oscillation
    private bool direction = true; // true = moving to max, false = moving to min

    private void FixedUpdate()
    {
        // set the target position
        if(direction && axisOfMovement) // if moving to maximum on x axis
            moveTowards(new Vector2(maxCoordinate, transform.position.y));
        if(!direction && axisOfMovement) // if moving to minimum on x axis
            moveTowards(new Vector2(minCoordinate, transform.position.y));
        if (direction && !axisOfMovement) // if moving to maximum on y axis
            moveTowards(new Vector2(transform.position.x, maxCoordinate));
        if (!direction && !axisOfMovement) // if moving to minimum on y axis
            moveTowards(new Vector2(transform.position.x, minCoordinate));
    }

    private void moveTowards(Vector2 targetPosition)
    {
        // moves towards target at the set speed
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);

        // Checks if the platform has reached a limit position
        if (axisOfMovement && transform.position.x == maxCoordinate)
            direction = !direction; // Change direction
        if (axisOfMovement && transform.position.x == minCoordinate)
            direction = !direction; // Change direction
        if (!axisOfMovement && transform.position.y == maxCoordinate)
            direction = !direction; // Change direction
        if (!axisOfMovement && transform.position.y == minCoordinate)
            direction = !direction; // Change direction
    }
}
