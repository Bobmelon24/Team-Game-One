using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScriptV2 : MonoBehaviour
{
    private float horizonal;
    public float speed = 8f;
    public float jumpPower = 16f;
    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        
        horizonal = Input.GetAxisRaw("Horizontal");

        /*
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(rb.velocity.x, Vector2.right * speed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = Vector2.left * speed;
        }
        */

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(Input.GetKeyDown(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); 
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizonal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizonal < 0f || !isFacingRight && horizonal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
