using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    
    public AudioSource Audio;

    public AudioClip EnemyDeath;

    public AudioClip Flashlight;

    public AudioClip PlayerHurt;

    public AudioClip PlayerHurt2;

    public AudioClip BatteryGet;

    public AudioClip Shoot;

    public AudioClip Reload;

    public AudioClip PlayerDead;

    public static SoundEffects SoundEffectsInstance;

    private void Awake()
    {
        if (SoundEffectsInstance != null && SoundEffectsInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        SoundEffectsInstance = this;
        DontDestroyOnLoad(this);
    }
}

