using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    // code for the actual HP bar 

    public Slider slider;   // reference to slider

    public void setMaxHealth(int health)   // make sure slider starts at max health
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)   // returns health integer
    {
        slider.value = health;  // the value on slider is health integer
    }

}
