using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // inspector elements
    [SerializeField] private PlayerStateManager player;
    [SerializeField] private float xDestination;
    [SerializeField] private float yDestination;
    [SerializeField] private AudioSource teleportAS;

    // when player touches the object, they are moved to the specified coords
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.setPosition(xDestination, yDestination);
        player.setVelocity(new Vector2(0,0));
        teleportAS.Play();
    }
}
