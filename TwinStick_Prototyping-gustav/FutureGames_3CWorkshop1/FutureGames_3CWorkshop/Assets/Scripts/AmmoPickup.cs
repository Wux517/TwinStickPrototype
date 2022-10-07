using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Reload(other);
        }
    }

    void Reload(Collider player)
    {
        Debug.Log("Reload");

        Destroy(gameObject);
        Gun stats = player.GetComponent<Gun>();
        stats.currentAmmo = stats.currentAmmo + 9;




        // spawn cool effect
        // apply effect

    }
}
