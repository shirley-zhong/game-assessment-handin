using UnityEngine;
using System.Collections;

public class Pivot : MonoBehaviour
{


    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10.0f;                                             //The distance from the camera to the arm object
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);     // convert point from screen space to world space
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;    // returns angle values from mouse position
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  // takes the mouse angle and rotates arm from pivot


    }
}