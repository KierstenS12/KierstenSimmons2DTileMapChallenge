using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMover : MonoBehaviour
{
    public float speed;
    private GameObject wallHitBox;
    public float wallHitWidth;
    public float wallHitHeight;
    private bool wallHit;
    public Transform wallhitbox;
    public float checkRadius;
    public LayerMask isGround;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
        
    void FixedUpdate()
    {
        wallHit = Physics2D.OverlapBox(wallhitbox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {  
        if (wallHit == true)
        {
            speed = speed* -1;
        }
    }
}

