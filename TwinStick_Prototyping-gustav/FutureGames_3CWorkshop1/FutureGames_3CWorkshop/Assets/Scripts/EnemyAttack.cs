using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float enemyDPS;

    private float soundTimer = 0;
    private float soundLenght = 2;

   


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage(other);
            //SlowPlayer(other);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            SlowPlayer(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            ResetPlayer(other);
    }

    private void TakeDamage(Collider player)
    {


        PlayerAttributes stats = player.GetComponent<PlayerAttributes>();
        stats.health -= Time.deltaTime;

        soundTimer += Time.deltaTime;
        if (soundTimer >= soundLenght)
        {
            SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.PlayerHurt);
            soundTimer = 0;
        }

    }
    

    private void SlowPlayer(Collider player)
    {
        PlayerMovementController stats = player.GetComponent<PlayerMovementController>();
        stats.accelerationDuration = stats.accelerationDuration = 2.5f;
    }

    private void ResetPlayer(Collider player)
    {

        PlayerMovementController stats = player.GetComponent<PlayerMovementController>();
        stats.accelerationDuration = stats.accelerationDuration = 0.5f;
    }
}

    