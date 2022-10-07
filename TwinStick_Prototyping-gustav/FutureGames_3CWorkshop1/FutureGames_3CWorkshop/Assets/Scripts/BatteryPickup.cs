using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BatteryPickup : MonoBehaviour
{
   // Start is called before the first frame update
    public GameObject pickupEffect;
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Recharge(other);
        }
    }

    void Recharge(Collider player)
    {
        Debug.Log("Recharge");


        Destroy(gameObject);

        Flashlight.ReplaceBattery(2.5f);
        

        // spawn cool effect
        // apply effect

    }
}
