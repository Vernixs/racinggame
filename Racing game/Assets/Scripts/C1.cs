using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1 : MonoBehaviour
{
    // Car parameters
    public float mass = 1200f;     // mass of car in kg
    public float dragCoeff = 0.25f;  // drag coefficient of car
    public float tireGrip = 2f;     // grip of tires on road
    public float brakePower = 20000f;  // braking power of car
    public float maxSteerAngle = 30f;  // maximum steering angle of front wheels

    // Car state
    private float speed = 0f;     // current speed of car in m/s
    private float accel = 0f;     // current acceleration of car in m/s^2
    private float steerAngle = 0f;  // current steering angle of front wheels

    // Physics constants
    private const float g = 9.81f;    // gravitational constant
    private const float dt = 0.02f;   // simulation timestep

    // Cached components
    private Rigidbody rigidbodys;
    private Transform centerOfMass;
    private WheelCollider[] wheelColliders;

    private void Start()
    {
        rigidbodys = GetComponent<Rigidbody>();
        centerOfMass = transform.Find("CenterOfMass");
        wheelColliders = GetComponentsInChildren<WheelCollider>();

        // Set center of mass of rigidbody
        if (centerOfMass != null)
            rigidbodys.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        // Calculate inputs
        float throttleInput = Input.GetAxis("Vertical");
        float brakeInput = Input.GetKey(KeyCode.Space) ? 1f : 0f;
        float steerInput = Input.GetAxis("Horizontal");

        // Calculate forces
        float engineForce = throttleInput * mass * g;
        float dragForce = -dragCoeff * speed * speed;
        float brakeForce = brakeInput * brakePower;
        float gripForce = tireGrip * mass * g;

        // Calculate total force
        float totalForce = engineForce + dragForce - brakeForce;

        // Calculate acceleration
        accel = totalForce / mass;

        // Calculate new speed
        speed += accel * dt;

        // Apply steering
        steerAngle = steerInput * maxSteerAngle;
        wheelColliders[0].steerAngle = steerAngle;
        wheelColliders[1].steerAngle = steerAngle;

        // Calculate lateral force and apply it to wheels
        /*float lateralForce = gripForce * steerInput;
        wheelColliders[0].sidewaysFriction.stiffness = lateralForce / mass;
        wheelColliders[1].sidewaysFriction.stiffness = lateralForce / mass;*/

        // Apply forces to rigidbody
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            WheelHit hit;
            if (wheelColliders[i].GetGroundHit(out hit))
            {
                Vector3 force = wheelColliders[i].transform.up * hit.force;
                rigidbodys.AddForceAtPosition(force, hit.point);
            }
        }
    }
}
