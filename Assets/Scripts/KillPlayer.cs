using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;      // gets a reference to the spawn point object

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))               // if player tagged 'Player' collides with box collider of Kill Floor
            collision.transform.position = spawnPoint.position;     // move player position to spawn point
    }

}
