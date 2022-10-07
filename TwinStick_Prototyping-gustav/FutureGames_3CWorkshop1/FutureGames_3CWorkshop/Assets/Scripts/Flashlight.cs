using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    

    static Light m_Light;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    
    float  intensity;
    
    private float soundTimer = 0;
    private float soundLenght = 0.2f;

    //Input
    private bool FlashlightButtonPressed;
    private InputActionsMap inputControls;

    private void Awake()
    {
        if (inputControls == null)
        {
            inputControls = new InputActionsMap();
        }

        inputControls.Player.Flashlight.performed += cntxt => FlashlightButtonPressed = true;
        inputControls.Player.Flashlight.canceled += cntxt => FlashlightButtonPressed = false;

        inputControls.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        m_Light.intensity = Mathf.Clamp(m_Light.intensity, minBrightness, maxBrightness);
        if (drainOverTime == true && m_Light.enabled == true)
        {
            if(m_Light.intensity > minBrightness)
            {
                m_Light.intensity -= Time.deltaTime * (drainRate / 1000);
                 
            }
        }
        
        intensity = m_Light.intensity;
        
        BatteryBar.sliderValue = intensity;

        if(FlashlightButtonPressed == true)
        {
            m_Light.enabled = !m_Light.enabled;
            soundTimer += Time.deltaTime;
            if (soundTimer >= soundLenght)
            {
                SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.Flashlight);
                soundTimer = 0;
            }
            
        }


        /* if(Input.GetKeyDown(KeyCode.R))
         {
             ReplaceBattery(.3f);
         }*/
    }
    


    public static void ReplaceBattery(float amount)
    {
        SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.BatteryGet);
        m_Light.intensity += amount;
    }


}
