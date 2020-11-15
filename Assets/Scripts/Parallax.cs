using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// ~~~~~ Script for background ~~~~~ 

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;                                          
    public float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;                            // gets start position of sprite background
        length = GetComponent<SpriteRenderer>().bounds.size.x;      // gets x length of sprite background
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallaxEffect);                                         // multiplies the set amount of parallax in inspector by camera x position

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);    // updates sprite position
    }
}
