using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rd2d;

    public AudioSource musicSource;

    //jump clip
    public AudioClip audioClipOne;

    //win music
    public AudioClip audioClipTwo;

    public int win = 0;

    public float jumpRate;

    private float nextJump;

    internal static void FindObjectOfType<T>(object win)
    {
        throw new NotImplementedException();
    }


    //flips player character depending on which way they are facing
    private bool facingRight = true;
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
        rd2d = GetComponent<Rigidbody2D>();
        musicSource = GetComponent<AudioSource>();
    }

    //This will control the physics of the player character to move using rigid body method AddForce
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

    }

    //This controls the Jumping physics. This is done by detecting if the player is connected to the ground using tags.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                
            }

        }
    }

    //Coin collision using the unity tag Coin
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //win music plays
        if (collision.collider.tag == "Coin")
        {
            win = 1;
            musicSource.clip = audioClipTwo;
            musicSource.Play();
            Destroy(collision.collider.gameObject);
        }
    }

   
        // Update is called once per frame
        void Update()
    {
            //jump sound plays
            if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextJump)
            {
                nextJump = Time.time + jumpRate;
                musicSource.clip = audioClipOne;
                musicSource.Play();
            }

    }
}
