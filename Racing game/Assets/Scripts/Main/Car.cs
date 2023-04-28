using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    public Rigidbody sphereRB;
    public float forwardAccel, reverseAccel, maxSpeed, turnStrenght = 180f, gravityForce = 10f, dragOnGround = 3f;
    private float speedInput, turnInput;
    private bool grounded;
    public LayerMask isGrounded;
    public float groundRayLenght = 100f;
    public Transform groundRayPoint;
    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;

    //Acceleration and Max Speed
    private void Start()
    {
        sphereRB.transform.parent = null;
    }
    private void Update()
    {
        speedInput = 0f;
        if(Input.GetAxis("Vertical") > 0)
        {
            
            speedInput = Input.GetAxis("Vertical") + forwardAccel * 2000f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 2000f;
        }

        turnInput = Input.GetAxis("Horizontal");

       if (forwardAccel == maxSpeed)
        {
            forwardAccel = maxSpeed;
            Debug.Log(speedInput);
        }

        

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
