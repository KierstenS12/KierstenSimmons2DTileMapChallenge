using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser1 : MonoBehaviour
{
    public int numberOfCoins;
    private Component playerControllerScript;
    public GameObject playerController;
    public GameObject coin;
    public float bumpercheckWidth;
    public float bumpercheckHeight;
    private bool bumpercheckhit;
    public Transform bumpercheckbox;
    public float checkRadius;
    public LayerMask isGround;
    private bool hitOnceCheck = false;
    private bool bumpercheck;
    private bool hitCheckCode;
    // Use this for initialization
    void Start()
    {
        
    }

    // Just used for speed
    void Update()
    {
    playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (numberOfCoins >= 0)
            {
                    
                    numberOfCoins = numberOfCoins - 1;    //this line removes 1 coin from the total in the box
                    hitOnceCheck = true; // this line stops multiple coins from being collected
                    Instantiate(coin, this.transform.position, this.transform.rotation);
            }
         
        }
    
    }


}

