using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    public Rigidbody sphereRB;
    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrenght = 180f;
    private float speedInput, turnInput;

    private void Start()
    {
        sphereRB.transform.parent = null;
    }
    private void Update()
    {
        speedInput = 0f;
        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 10f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 10f;
        }


                transform.position = sphereRB.transform.position;
    }
    private void FixedUpdate()
    {
        if(Mathf.Abs(speedInput) > 0)
        {
            sphereRB.AddForce(transform.forward * speedInput);
        }
    }

}
