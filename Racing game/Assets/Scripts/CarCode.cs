using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    Vector3 tractiveForce;
    Vector3 drag;
    public float cDrag;
    public float torque;
    public float engineForce = 10.0f;
    Vector2 a = new Vector2(1.0f, 0.0f);
    Vector2 b = new Vector2(-1.0f, 0.0f);
    //public float 
    void Start()
    {
        
        tractiveForce = transform.forward * engineForce;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
