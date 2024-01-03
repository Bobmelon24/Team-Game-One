using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScriptV4 : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 10f;
    public float drag = 15f; // Increase drag value
    public bool InAir = false;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        // Apply drag to both X and Y components
        rb2d.velocity = rb2d.velocity * Mathf.Pow(0.95f, drag);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !InAir)
        {
            rb2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
