using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

using UnityEngine.Video;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform pickup;
        public int enemyAmount;
        public int pickupAmount;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 45f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn points");
        }

        //Time between Wave
        waveCountdown = timeBetweenWaves;
        
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            
                //Begin new Round
                
            WaveComplete();
                
            
            
        }
         
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //start spawning waves
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveComplete()
    {
        Debug.Log("Wave Complete");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves! Looping...");
        }
        else
        {
         nextWave++;
        }

    }

    bool EnemyIsDead()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }    
        
        return true;
        

    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("Spawning Wave" + wave.name);
        state = SpawnState.SPAWNING;
        
        //Spawn
        for (int i = 0; i <wave.enemyAmount; i++)
        {
            SpawnEnemy(wave.enemy);
            
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        for (int i = 0; i <wave.pickupAmount; i++)
        {
            
            SpawnEnemy(wave.pickup);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;
        
        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("Spawning");

        
        Transform sp = spawnPoints[ Random.Range (0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
    
    void SpawnPickup(Transform pickup)
    {
        Debug.Log("Spawning");
        Instantiate(pickup, transform.position, transform.rotation);
    }
}