using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //int for count here

    public Text countText;
    public Text winText;
    private Rigidbody2D rb2d;
    private bool facingRight = true;
    public int count;
    public float speed;
    public float jumpforce;


    

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;
    public GameObject coinBox;
    private int coinBoxCount;
    //audio stuff
    private AudioSource source;
    public AudioClip jumpClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    // set count to 0 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //count = 0;
        winText.text = "";
        //SetCountText();
        
    }


    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        coinBoxCount = coinBox.GetComponent<CoinDispenser1>().numberOfCoins;
        SetCountText();
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

        // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        //Debug.Log(isOnGround);



        //stuff I added to flip my character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }
    //here's where it adds the additional amount as I collect them.
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            // SetCountText();
        }
        else if (other.gameObject.CompareTag("Box"))
        {
            if (coinBoxCount >= 0)
            {
             count = count + 1;
             // SetCountText();
            }
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 36)
        {
            winText.text = "You Win!";
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpClip);

            }

        }
    }
}

