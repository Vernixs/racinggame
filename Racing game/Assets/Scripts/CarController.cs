using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider backLeftWheel;
    public WheelCollider backRightWheel;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;

    public Rigidbody carRigidbody;

    public float speed = 10.0f;
    public float turnSpeed = 10.0f;
    public float maxSteerAngle = 30.0f;

    private void Update()
    {
        // Get the horizontal input axis value
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the steer angle based on the horizontal input
        float steerAngle = maxSteerAngle * horizontalInput;

        // Set the steer angle for the front left and front right wheels
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

        // Animate the front wheels to rotate left or right based on the steer angle
        frontLeftWheelTransform.localEulerAngles = new Vector3(frontLeftWheelTransform.localEulerAngles.x, steerAngle, frontLeftWheelTransform.localEulerAngles.z);
        frontRightWheelTransform.localEulerAngles = new Vector3(frontRightWheelTransform.localEulerAngles.x, steerAngle, frontRightWheelTransform.localEulerAngles.z);

        // Apply a force to the car's rigidbody in a forward direction
        carRigidbody.AddForce(transform.forward * speed * Input.GetAxis("Vertical"), ForceMode.Acceleration);
    }
}






