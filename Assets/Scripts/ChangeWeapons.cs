using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    public Sprite Pistol;
    public Sprite MachineGun;   // Gets pistol and rifle

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)        // if mouse scroll wheel is up then
        {
            GetComponent<SpriteRenderer>().sprite = Pistol;         // render pistol sprite
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)       // if mouse scroll wheel is down then
        {
            GetComponent<SpriteRenderer>().sprite = MachineGun;     // render rifle sprite
        }


    }
}
