using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    [SerializeField] private  Slider slider;
    public static float sliderValue = 100;

    public void SetMaxHealth(int intensity)
    {



        slider.maxValue = intensity;
        slider.value = intensity;
    }

    public void SetHealth(int intensity)
    {
        slider.value = intensity;
    }
    public void Start()
    {

    }
    public void Update()
    {
        slider.value = sliderValue;
    }
}
