using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    public Rigidbody sphereRB;
    private float reverseAccel, turnStrenght = 180f, gravityForce = 10f, dragOnGround = 3f;
    private float speedInput, turnInput;
    private bool grounded;
    private bool isBraking;
    public LayerMask isGrounded;
    private float groundRayLenght = 100f;
    public Transform groundRayPoint;
    public Transform leftFrontWheel, rightFrontWheel;
    private float maxWheelTurn = 25f;
    public float brakeForce = 1000f;
    public float speed = 5f;

    public float maxSpeed = 100f;
    public float forwardAccel = 0.9f;




    //Acceleration and Max Speed
    private void Start()
    {
       
        sphereRB.transform.parent = null;
    }


    private void Update()
    {
        speedInput = Input.GetAxis("Vertical");
        if (speedInput > 0)
        {
            if (speed < maxSpeed)
            {
                speed += forwardAccel * Time.deltaTime;
            }
            else
            {
                speed = maxSpeed;
            }
        }
        else if (speedInput <0)
        {
            if (speed > 0)
            {
                speed -= brakeForce * Time.deltaTime;
            }
        }
        else
        {
            if(speed > 0)
            {
                speed -= forwardAccel * Time.deltaTime;
            }
        }

        turnInput = Input.GetAxis("Horizontal");
        turnInput = turnInput * (speed / maxSpeed);

        float latSpeed = 0;

        if (turnInput > 0)
        {
            latSpeed = -CalculateCentripedalForce(speed, 70f, 10000f);
        }
        else if (turnInput < 0)
        {
            latSpeed = CalculateCentripedalForce(speed, 70f, 10000f);

        }

        //Turning 

        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));

        

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 90, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn -90, rightFrontWheel.localRotation.eulerAngles.z);

        sphereRB.velocity = (speed * transform.forward) + (latSpeed * transform.right);

        transform.position = sphereRB.transform.position;



    }


    private void FixedUpdate()
    {
       grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLenght, isGrounded))
        {
            
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if(grounded)
        {
            sphereRB.drag = dragOnGround;

            if(Mathf.Abs(speedInput) > 0)
            {
                sphereRB.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            sphereRB.drag = 0.1f;

            sphereRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
        
    }

    public float CalculateCentripedalForce(float speed, float weight, float radius)
    {

        //convert kmh to meter per second
        float speedInMeter = speed * 1000.0f * (1.0f / 3600.0f);

        //centripedal acceleration in meter per second squared
        float cA = (speedInMeter * speedInMeter) / radius;

        //centripedal force in newton
        float cF = weight * cA;

        return cF;

    }

}
