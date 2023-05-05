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
    private float brakeForce = 1000f;
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


        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
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
        else
        {
            if(speed > 0)
            {
                speed -= forwardAccel * Time.deltaTime;
            }
        }

        turnInput = Input.GetAxis("Horizontal");


        //Turning 

        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));

        

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 90, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn - 90, rightFrontWheel.localRotation.eulerAngles.z);

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

}
