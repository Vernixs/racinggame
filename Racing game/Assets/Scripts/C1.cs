using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1 : MonoBehaviour
{
    public float maxMotorTorque = 1000f;
    public float maxBrakeTorque = 2000f;
    public float maxSteeringAngle = 30f;
    public float wheelRadius = 0.33f;
    public float wheelFriction = 1.5f;
    public float drag = 0.1f;
    public float angularDrag = 0.5f;

    private Rigidbody carRigidbody;
    private WheelCollider[] wheels;

    private float motorTorque = 100f;
    private float brakeTorque = 50f;
    private float steeringAngle = 30f;

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        wheels = GetComponentsInChildren<WheelCollider>();

        foreach (WheelCollider wheel in wheels)
        {
            wheel.radius = wheelRadius;
            wheel.forwardFriction.stiffness = wheelFriction;
            wheel.sidewaysFriction.stiffness = wheelFriction;
        }

        carRigidbody.drag = drag;
        carRigidbody.angularDrag = angularDrag;
    }

    void Update()
    {
        motorTorque = Input.GetAxis("Vertical") * maxMotorTorque;
        brakeTorque = Input.GetKey(KeyCode.Space) ? maxBrakeTorque : 0f;
        steeringAngle = Input.GetAxis("Horizontal") * maxSteeringAngle;
    }

    void FixedUpdate()
    {
        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = motorTorque / wheels.Length;
            wheel.brakeTorque = brakeTorque / wheels.Length;
            wheel.steerAngle = steeringAngle;
        }
    }
}
