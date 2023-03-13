using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Engine : MonoBehaviour
{
    
    public float cDrag = 10f;
    public float torque = 500f;
    public float engineForce = 10.0f;
    public float acceleration;
    public float timeIncrement;
    public float mass;
    public float netForce;
    public float speed = 100f;
    public float coefficientOfFriction = 0.1f;
    float airResistance;
    float densityOfAir;
    float airDensity = 1.29f;
    float frontAreaCar = 2.2f;
    float airResults;
    float maxTractionForce;
    float frictionCoeffiecientTyre = 1f;
    float weight;
    float rCG;
    float fCG;
    

    Vector2 a = new Vector2(1.0f, 0.0f);
    Vector2 b = new Vector2(-1.0f, 0.0f);
    
    Vector3 rollingResistance;
    Vector3 longtitudinalForce;
    Vector3 carVelocity;
    Vector3 carPosition;
    Vector3 tractiveForce;
    Vector3 fDrag;
    Vector3 brakingForce;

    public GameObject[] backWheels;
    public GameObject[] frontWheels;


    void Start()
    {
        
    }

    void Update()
    {

       

    }


    void drivingStraight()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 vel = rb.velocity;
        tractiveForce = transform.forward * engineForce;
        fDrag = -cDrag * vel * vel.magnitude;
        speed = Mathf.Sqrt(vel.x * vel.x + vel.y * vel.y);
        fDrag.x = -cDrag * vel.x * speed;
        fDrag.y = -cDrag * vel.y * speed;
        rollingResistance = -cDrag * vel;
        longtitudinalForce = tractiveForce + fDrag + rollingResistance;
        acceleration = netForce / mass;
        // vel = vel.normalized + (timeIncrement * acceleration);
        carPosition = carPosition + timeIncrement * vel;
    }

    /*void Air()
    {
        Debug.Log(speed);
        speed = speed * speed;
        airResistance = (float)(0.5 * coefficientOfFriction * frontAreaCar * densityOfAir * speed);
        airDensity = (float)(0.5 * 0.30 * 2.2 * 1.29);
        airResults = 30 * airDensity;

    }*/

    void braking()
    {
        longtitudinalForce = brakingForce + fDrag + rollingResistance;
        //brakingForce = -transform.forward * ;
    }

    /*void WeightTransfer()
    {
        maxTractionForce = frictionCoeffiecientTyre * weight;
        //frontWheels = (fCG / L) * weight;
        //rearWheels = (rCG / L) * weight;
    }*/
}
