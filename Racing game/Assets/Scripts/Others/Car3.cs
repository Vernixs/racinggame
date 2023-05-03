using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car3 : MonoBehaviour
{
    public float maxSpeed = 20f; // Maximum speed in m/s
    public float acceleration = 10f; // Acceleration in m/s^2
    public float deceleration = 20f; // Deceleration in m/s^2
    public float turnSpeed = 3f; // Turning speed in radians/s
    public float brakeForce = 1000f; // Braking force

    private Rigidbody rb;
    private float forwardInput;
    private float turnInput;
    private bool isBraking;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxSpeed / transform.localScale.magnitude;
    }

    private void FixedUpdate()
    {
        // Get user input
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        isBraking = Input.GetKey(KeyCode.Space);

        // Calculate speed
        float speed = rb.velocity.magnitude;

        // Apply acceleration or deceleration
        float accelerationInput = forwardInput - (isBraking ? 1f : 0f);
        float accelerationMagnitude = accelerationInput * acceleration;
        float decelerationMagnitude = -deceleration;
        float forceMagnitude = accelerationMagnitude + decelerationMagnitude;

        if (speed < maxSpeed || forceMagnitude < 0)
        {
            Vector3 force = transform.forward * forceMagnitude;
            rb.AddForce(force, ForceMode.Acceleration);
        }

        // Apply turning
        float turnAngle = turnInput * turnSpeed;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAngle, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // Apply braking
        if (isBraking)
        {
            rb.AddForce(-rb.velocity.normalized * brakeForce, ForceMode.Acceleration);
        }
    }
}

