using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.VisualScripting.InputSystem;

[RequireComponent(typeof(InputActionsMap))]

public class Gun : MonoBehaviour
{
  

    //Pelets and Shotgu
    public int pelletCount;
    public float spreadAngle;
    public GameObject Pellet;
    public Transform GunEndPoint;
    public float pelletFireVelocity = 1;
    public List<Quaternion> pellets;

    //Timer
    public float shootCooldown = 0.5f;
    public float shootTimer;

    //Mag
    public int maxMag;
    public int currentMag;
    public int maxAmmo;
    public int currentAmmo;
    public float ReloadTime = 3f;
    public bool isReloading = false;

    public float canShoot;

    private bool shootButtonPressed; 
    private bool reloadButtonPressed;
    private InputActionsMap inputControls;
    
    private float soundTimer = 0;
    private float soundLenght = 0.2f;




    void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);    //Adds pellets To shoot
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));

        }
        shootTimer = 0.5f;
        currentAmmo = maxAmmo;
        currentMag = maxMag;

        //Input -THE TRUE INPUT SYTEM BY THE PROGRAMMER GOD
        if(inputControls == null)
        {
            inputControls = new InputActionsMap();
        }

        inputControls.Player.Fire.performed += cntxt => shootButtonPressed = true;
        inputControls.Player.Fire.canceled += cntxt => shootButtonPressed = false;
        Debug.Log(shootButtonPressed);
       
        inputControls.Player.Reload.performed += cntxt => reloadButtonPressed = true;
        inputControls.Player.Reload.canceled += cntxt => reloadButtonPressed = false;

        inputControls.Enable();
    }


    void shotoButtonPressed(float value)
    {
      
       if(value > 0.1)
        {
            shootButtonPressed = true;
        }
        else
        {
            shootButtonPressed = false;
        }
    }


    void Update()   //When pressing fire button, fire
    {
        shootTimer += Time.deltaTime; //Keeps track of time
                                      // Change to whatever controll is fire
        canShoot += Time.deltaTime;

        if (shootButtonPressed == true && canShoot > 2 && currentMag > 0)     //When shooting this happens
        {
            
            Fire();
            SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.Shoot);
            shootTimer = 0;
            canShoot = 0;
            //currentMag--;
            currentMag = currentMag - 1;
            //Debug.Log("How many times am I shooting" + currentMag);
        }

        Debug.Log(shootButtonPressed);
        //Reload
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            currentAmmo = 9 ; 
        }


        if(reloadButtonPressed == true)     //When reloading this happens
        {
            Debug.Log("reload");
           if (currentMag == 2 && currentAmmo >= 1)
            {
                currentMag = currentMag + 1;
                currentAmmo = currentAmmo - 1;
            }

            if (currentMag == 1 && currentAmmo >= 2)
            {
                currentMag = currentMag + 2;
                currentAmmo = currentAmmo - 2;
            }

            if (currentMag == 0 && currentAmmo >= 3)
            {
                currentMag = currentMag + 3;
                currentAmmo = currentAmmo - 3;
            }
            ;

            soundTimer += Time.deltaTime;
            if (soundTimer >= soundLenght)
            {
                SoundEffects.SoundEffectsInstance.Audio.PlayOneShot(SoundEffects.SoundEffectsInstance.Reload);
                soundTimer = 0;
            }
            ;
        }

        /* //C = Pickup (aka change to pickup when added pickup)
        
         currentAmmo = currentAmmo + 3;
         Debug.Log("Pick up");*/

        void Fire()
        {
            if (shootTimer >= 2 && currentMag > 0)
            {
                for (int i = 0; i < pelletCount; i++) //Spread of Shotgun . In following "pel" is pellet
                {
                    pellets[i] = Random.rotation;
                    GameObject pel = Instantiate(Pellet, GunEndPoint.position, GunEndPoint.rotation);
                    pel.transform.rotation = Quaternion.RotateTowards(pel.transform.rotation, pellets[i], spreadAngle);
                    pel.GetComponent<Rigidbody>().AddForce(pel.transform.right * pelletFireVelocity);
                    i++;
                    Destroy(pel, 1f);
                }
            }
        }
    }
}
