using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFloating : MonoBehaviour
{
    public float floatHeight = 1.0f; // Height above the ground that the camera floats
    public float floatDamping = 0.5f; // Damping factor for the camera float
    public float horizontalSpeed = 1.0f; // Speed of the horizontal camera movement
    public float verticalSpeed = 1.0f; // Speed of the vertical camera movement
    public float maxHorizontalOffset = 1.0f; // Maximum horizontal offset from the center
    public float maxVerticalOffset = 1.0f; // Maximum vertical offset from the center

    private Vector3 originalPosition; // Original position of the camera
    private float horizontalOffset = 0.0f; // Current horizontal offset from the center
    private float verticalOffset = 0.0f; // Current vertical offset from the center

    void Start()
    {
        originalPosition = transform.localPosition; // Save the original position of the camera
    }

    void Update()
    {
        // Calculate the target position of the camera based on the original position, horizontal and vertical offsets, and float height
        Vector3 targetPosition = originalPosition + new Vector3(horizontalOffset, floatHeight, verticalOffset);

        // Set the position of the camera to the target position with damping
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * floatDamping);

        // Update the horizontal and vertical offsets based on time and speed
        horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * maxHorizontalOffset;
        verticalOffset = Mathf.Cos(Time.time * verticalSpeed) * maxVerticalOffset;
    }
}

