using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftController : MonoBehaviour
{
    public float jumpForce = 5f; // The force of the jump when drifting
    public KeyCode driftKey = KeyCode.Space; // The key to press to start drifting

    private bool isDrifting = false; // Whether the car is currently drifting
    private Rigidbody2D rb; // The Rigidbody2D component of the car

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the drift key is pressed
        if (Input.GetKeyDown(driftKey) && !isDrifting)
        {
            // Start drifting
            isDrifting = true;

            // Add a jump force to the car to make it drift
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Stop drifting when the car collides with something
        if (isDrifting)
        {
            isDrifting = false;
        }
    }
}

