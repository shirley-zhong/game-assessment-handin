  using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{

    public Sprite Pistol;
    public Sprite Rifle;   // Gets pistol and rifle


    // Script for shooting and fire rate

    public GameObject projectile;        // reference to projectile prefab
    public GameObject shotBurst;         // reference burst particle effect
    public Transform pistolshotPoint;   // fire point where bullets come out

    private float timeBtwShots;         // time between shots
    public float startTimeBtwShots = 0.5f;     // start time for time between shots. 
    public bool isShooting = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shooting();
        changeWeapon();
    }

    void shooting()
    {
        if (timeBtwShots <= 0)

        {
            if (Input.GetKey(KeyCode.Mouse0))       // if left mouse is pressed
            {
                Instantiate(projectile, pistolshotPoint.position, transform.rotation);      // shoot projectile
                timeBtwShots = startTimeBtwShots;
                Instantiate(shotBurst, transform.position, Quaternion.identity);            // spawn shot burst effect

                isShooting = true;


            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

            isShooting = false;
        }
    }

    void changeWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)        // if mouse scroll wheel is up then
        {
            GetComponent<SpriteRenderer>().sprite = Pistol;         // render pistol sprite
            startTimeBtwShots = 0.5f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)       // if mouse scroll wheel is down then
        {
            GetComponent<SpriteRenderer>().sprite = Rifle;     // render rifle sprite
            startTimeBtwShots = 0.2f;
        }
        
    }





}
