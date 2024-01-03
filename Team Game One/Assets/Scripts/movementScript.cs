using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movementScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;
    public float jumpSpeed;
    public bool hasCollided;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            myRigidbody.velocity = Vector2.right * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            myRigidbody.velocity = Vector2.left * moveSpeed;
        }


        if (Input.GetKeyDown(KeyCode.W) && hasCollided == true) 
        {
            myRigidbody.velocity = Vector2.up * jumpSpeed;
            hasCollided = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;
    }

}
