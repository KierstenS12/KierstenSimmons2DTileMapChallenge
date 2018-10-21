using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {
    
    private GameObject enemy;
    public float wallHitWidth;
    public float wallHitHeight;
    private bool playerHit;
    public Transform weakspot;
    public float checkRadius;
    public LayerMask isGround;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void FixedUpdate()
    {
        playerHit = Physics2D.OverlapBox(weakspot.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "groundcheck" && playerHit == true)
        {
   
            Debug.Log("Goomba dead");
            Destroy(gameObject);
        }
    }
}


