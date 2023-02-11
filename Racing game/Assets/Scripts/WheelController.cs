using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float BrakingForce = 300f;
    public float MaxturnAngle = 30f;

    private float CurrentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;
    private void FixedUpdate()
    {
        //Forward and Reverse using vertical axis (W and S keys)
        CurrentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))

            currentBrakeForce = BrakingForce;
        else
            currentBrakeForce = 0f;

        frontRight.motorTorque = CurrentAcceleration;
        frontLeft.motorTorque = CurrentAcceleration;
        //Apply Brakes
        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        rearRight.brakeTorque = currentBrakeForce;
        rearLeft.brakeTorque = currentBrakeForce;
        //Steering
        currentTurnAngle = MaxturnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        //UpdateWheel(frontLeft, frontLeftTransform);
       // UpdateWheel(frontRight, frontRightTransform);
       // UpdateWheel(rearLeft, backLeftTransform);
       // UpdateWheel(rearRight, backRightTransform);
    }

   // void UpdateWheel(WheelCollider col, Transform trans)
    
     //   Vector3 position;
      //  Quaternion rotation;
      //  col.GetWorldPose(out position, out rotation);

      //  trans.position = position;
       // trans.rotation = rotation;
}


