using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Engine : MonoBehaviour
{
    Vector3 tractiveForce;
    Vector3 fDrag;
    public float cDrag;
    public float torque;
    public float engineForce = 10.0f;
    Vector2 a = new Vector2(1.0f, 0.0f);
    Vector2 b = new Vector2(-1.0f, 0.0f);
    public float speed;
    Rigidbody rb;
    Vector3 rr;
    Vector3 longtitudinalForce;
    public float acceleration;
    void Start()
    {
       
    }

    void Update()
    {
        Vector3 vel = rb.velocity;
        tractiveForce = transform.forward * engineForce;
        fDrag = -cDrag * vel * vel.magnitude;
        speed = Mathf.Sqrt(vel.x * vel.x + vel.y * vel.y);
        fDrag.x = -cDrag * vel.x * speed;
        fDrag.y = -cDrag * vel.y * speed;
        rr = -cDrag * vel;
        longtitudinalForce = tractiveForce + fDrag + rr;
        
    }
}
