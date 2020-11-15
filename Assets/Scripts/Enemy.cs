using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    public int health;                  // health can be set for each enemy type in inspector
    public GameObject deathEffect;


    // Start is called before the first frame update


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();      // set target as player (tagged 'player')
    }

    // Update is called once per frame
    public void Update()
    {
        followPlayer();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;   // health = health - damage taken

        if (health <= 0)    
        {
            Die();          // if health decreases <= 0, trigger Die() function

            CameraShaker.Instance.ShakeOnce(4.0f, 0.8f, 0.1f, 0.15f);
        }
    }

    void Die()  // when dead
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);      // instantiate death effect
        Destroy(gameObject);        // destroy enemy object
    }

    private void OnTriggerEnter2D(Collider2D collision)    
    {
        if (collision.tag == "Player")      // when enemy collides with player
        {
            Destroy(gameObject);            // destroy enemy object
        }

        if (collision.CompareTag("Environment"))
        {
            this.transform.position += transform.up * Time.deltaTime * 0f;
        }
    }

    void followPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // change the position of enemy by moving toward player position

    }
}
