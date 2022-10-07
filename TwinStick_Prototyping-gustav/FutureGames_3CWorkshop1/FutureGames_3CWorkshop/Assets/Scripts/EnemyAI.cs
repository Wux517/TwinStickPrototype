using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent enemy;
   // public Vector3 offset;

    public GameObject player;
    //private Transform target;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //target = player.transform;
        
        
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, 0.003f);
        enemy.SetDestination(player.transform.position);
    }
}
