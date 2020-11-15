using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth;           // max health set in inspector
    public int currentHealth;       // current health 
    public HealthBar healthBar;     // reference to healthbar script
    public GameObject playerDeathEffect;
    

    void Start()
    {
        currentHealth = maxHealth;              // player starts with max health
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damage)                 // returns currentHealth value
    {
        currentHealth -= damage;                // currentHealth will be health - damage
        healthBar.SetHealth(currentHealth);
        gameObject.GetComponent<Animation>().Play("TakeDamage");


        // Player death 
        if (currentHealth == 0)                                                               // If current health decreases to 0
        {
            Destroy(gameObject);                                                            // Player dies
            Instantiate(playerDeathEffect, transform.position, Quaternion.identity);        // and particle effects instantiates

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Small alien")             // small alien does 10 dmg
        {
            TakeDamage(10);
        }

        if (collision.tag == "Medium alien")            // medium alien does 30 dmg
        {
            TakeDamage(30);
        }
    }

}
