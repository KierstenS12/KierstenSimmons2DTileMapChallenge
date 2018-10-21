using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser : MonoBehaviour
{
    public int numberOfCoins;
    private PlayerController playerControllerScript;
    public GameObject playerController;
    public float bumpercheckWidth;
    public float bumpercheckHeight;
    private bool bumpercheckhit;
    public Transform bumpercheckbox;
    public float checkRadius;
    public LayerMask isGround;

    // Use this for initialization
    void Start()
    {
        playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    // Just used for speed
    void Update()
    {
        
    }
     // code used to make a Goomba hit the wall and then change direction.   
    void FixedUpdate()
    {
       bumpercheckhit = Physics2D.OverlapBox(bumpercheckbox.position, new Vector2(bumpercheckWidth, bumpercheckHeight), 0, isGround);

        if (bumpercheckhit == true)
        {
           
            
        }
        if (numberOfCoins >= 0)
        {
            playerControllerScript.count = playerControllerScript.count + 1; //This line adds an extra coin to the player's total
            numberOfCoins = numberOfCoins - 1;    //this line removes 1 coin from the total in the box
                                                  //This is a spare line for adding SFX and sprite animation later
        }
    }
    

}

