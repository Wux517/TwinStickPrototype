using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name != "enemy")
        {
            if (collisionGameObject.GetComponent<EnemyHealth>() != null)
            {
                collisionGameObject.GetComponent<EnemyHealth>().TakeDamage(damage); //should say damage but doesn't work
            }
        }
    }
}
