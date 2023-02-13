using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel, frontRightWheel;
    public WheelCollider backLeftWheel, backRightWheel;
    public Transform frontLeftWheelMesh, frontRightWheelMesh;
    public Transform backLeftWheelMesh, backRightWheelMesh;
    public float maxSteerAngle = 30.0f;
    public float motorForce = 50.0f;
    public float engineRPM;
    private float steerInput = 0.0f;
    private float throttleInput = 0.0f;

    private GearShift gearShift;

    private void Start()
    {
        gearShift = GetComponent<GearShift>();
    }

    private void Update()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    private void GetInput()
    {
        steerInput = Input.GetAxis("Horizontal");
        throttleInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        float steerAngle = steerInput * maxSteerAngle;
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;
    }

    private void Accelerate()
    {
        float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        float currentGearRatio = gearShift.gearRatios[gearShift.currentGear];
        float engineRPM = currentSpeed / currentGearRatio;
        engineRPM = Mathf.Clamp(engineRPM, 0.0f, 7000.0f);

        float adjustedMotorForce = motorForce * currentGearRatio * throttleInput;
        frontLeftWheel.motorTorque = adjustedMotorForce;
        frontRightWheel.motorTorque = adjustedMotorForce;
        backLeftWheel.motorTorque = adjustedMotorForce;
        backRightWheel.motorTorque = adjustedMotorForce;

        
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeftWheel, frontLeftWheelMesh);
        UpdateWheelPose(frontRightWheel, frontRightWheelMesh);
        UpdateWheelPose(backLeftWheel, backLeftWheelMesh);
        UpdateWheelPose(backRightWheel, backRightWheelMesh);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform mesh)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        mesh.position = position;
        mesh.rotation = rotation;
    }
}






