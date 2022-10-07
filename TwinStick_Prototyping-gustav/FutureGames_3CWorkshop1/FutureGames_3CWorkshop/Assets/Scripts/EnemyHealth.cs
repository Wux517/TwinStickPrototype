using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.EnemyDeath);
            
            Destroy(gameObject);
            Debug.Log("Has Destroyed ENEMY");
         
         
        }
    }
}
