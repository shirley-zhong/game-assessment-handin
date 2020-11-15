using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage = 10;     // projectile does 10 dmg

    public GameObject destroyEffect;
    public LayerMask whatIsSolid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);    // calculate projectile speed

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);      // use raycasts to detect collision
        if (hitInfo.collider != null)                                                                           // if collision info is none
        {
            if (hitInfo.collider.CompareTag("Small alien"))                                                     // if collision info detects small alien
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);                                      // take 10 dmg
            }

            if (hitInfo.collider.CompareTag("Medium alien"))                                                    // if collision info detects medium alien
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);                                      // take 10 dmg
            }

                DestroyProjectile();                                                                            // destroy projectile when collided
        }

       
 
    }


/*    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DestroyProjectile();
        }
    }
*/

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);    
        Destroy(gameObject);        // destroy bullet
    }



}
