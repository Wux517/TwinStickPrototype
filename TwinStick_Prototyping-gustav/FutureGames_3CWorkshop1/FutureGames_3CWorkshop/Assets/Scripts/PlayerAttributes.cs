using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float health;

    void Update()
    {
        if (health <= 0)
        {
            SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.PlayerDead);
            Destroy(gameObject);
            Debug.Log("Has Destroyed ENEMEMY");
            
        }
        
        Healthbar.sliderValue = health;

       
    

    }

   

   
    
}
