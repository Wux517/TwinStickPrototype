using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private  Slider slider;
    public static float sliderValue = 100;

    public void SetMaxHealth(int health)
    {



        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    
    public void Update()
    {
        slider.value = sliderValue;
    }
}
