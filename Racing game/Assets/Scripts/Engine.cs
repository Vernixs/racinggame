using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Engine : MonoBehaviour
{
    Vector3 tractiveForce;
    Vector3 fDrag;
    public float cDrag = 10;
    public float torque = 500;
    public float engineForce = 10.0f;
    Vector2 a = new Vector2(1.0f, 0.0f);
    Vector2 b = new Vector2(-1.0f, 0.0f);
    public float speed = 100;
    Vector3 rollingResistance;
    Vector3 longtitudinalForce;
    public float acceleration;
    public float timeIncrement;
    public float mass;
    public float netForce;
    Vector3 carVelocity;
    Vector3 carPosition;
    void Start()
    {
        
    }

    void Update()
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
}
