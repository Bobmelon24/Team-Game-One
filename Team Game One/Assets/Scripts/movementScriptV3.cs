using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10f;
    public float JumpHeight = 10f;
    public bool InAir = false;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Makes sure that the rigid body can be called later
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InAir = false;
        Debug.Log("InAir false");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        InAir = true;
        Debug.Log("InAir True");
    }

    void FixedUpdate()
    {
        Vector2 NoMovement = new Vector2(0f, 0f);  //No idea what this is for...

        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y); //Right Movement

            }
        }
        if (moveHorizontal < 0)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y); //Left Movement
        }

        /*
        if (Input.GetKeyDown(KeyCode.W) && InAir == false)
        {
            rb2d.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse);
        }
        */

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && InAir == false) 
        {
            rb2d.AddForce(new Vector2(0, JumpHeight), ForceMode2D.Impulse); //Jump Code
        }
    }
}
        