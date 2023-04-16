using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the car
    public float returnDuration = 3.0f; // Time until the car returns to original position in seconds
    public Vector3 direction = Vector3.right; // Direction the car is moving in

    private Vector3 originalPosition; // Original position of the car
    private float elapsedTime = 0.0f; // Elapsed time since the car started moving

    void Start()
    {
        originalPosition = transform.position; // Save the original position of the car
    }

    void Update()
    {
        // Move the car in the specified direction at the specified speed
        transform.position += direction * speed * Time.deltaTime;

        // Check if the car has moved for the specified duration
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= returnDuration)
        {
            // Teleport the car back to its original position
            transform.position = originalPosition;

            // Reset the elapsed time
            elapsedTime = 0.0f;
        }
    }
}
