﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser : MonoBehaviour
{
   
    public int numberOfCoins;
    private PlayerController playerControllerScript;
    public GameObject playerController;
    public GameObject coin;
    public float bumpercheckWidth;
    public float bumpercheckHeight;
    private bool bumpercheckhit;
    public Transform bumpercheckbox;
    public float checkRadius;
    public LayerMask Player;
    private bool hitOnceCheck = false;
    private bool bumpercheck;
    private bool hitCheckCode;
    // Use this for initialization
    void Start()
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    // Just used for speed
    void Update()
    {
        
    }
       
    void FixedUpdate()
    {
        bumpercheckhit = Physics2D.OverlapBox(bumpercheckbox.position, new Vector2(bumpercheckWidth, bumpercheckHeight), 0, Player);

        if (bumpercheck == true)
        {
            if (hitOnceCheck == false)
            {
                if (numberOfCoins >= 0)
                {
                    playerControllerScript.count = playerControllerScript.count + 1; //This line adds an extra coin to the player's total
                    numberOfCoins = numberOfCoins - 1;    //this line removes 1 coin from the total in the box
                    hitOnceCheck = true; // this line stops multiple coins from being collected
                    Instantiate(coin, this.transform.position, this.transform.rotation);
                    Debug.Log("I'veBeenHit");
                }
            }
        }
        else
        {
            hitOnceCheck = false; // this resets once bumpercheck says the player isn't colliding
        }


        }

    }
    



