using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


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

    bool accelerate = false;
    bool braking = false;
    bool turningLeft = false;
    bool turningRight = false;

    public InputActionAsset inputActions;
    InputActionMap gameplayActionMap;
    InputAction steeringAngle;
    InputAction accelerationcontrols;

    //Acceleration and Max Speed

    /*private void Awake()
    {
        gameplayActionMap = inputActions.FindActionMap("Movement");

        steeringAngle = gameplayActionMap.FindAction("Steeringangle");
        accelerationcontrols = gameplayActionMap.FindAction("Acceleration");

        steeringAngle.performed += ctx => turnInput  = ctx.ReadValue<float>();
        accelerationcontrols.performed += ctx => speedInput = ctx.ReadValue<float>();
        accelerationcontrols.canceled += ctx => speedInput = 0f;
    }*/

    public void Accelerate(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            Debug.Log("Accelerate");
            accelerate = true;
        } 
        else if (ctx.canceled) {
            Debug.Log("Stop accelerate");
            accelerate = false;
        }
    }

    public void Brake(InputAction.CallbackContext ctx) {
         if(ctx.performed) {
            Debug.Log("braking");
            braking = true;
        } 
        else if (ctx.canceled) {
            Debug.Log("stop brakinge");
            braking = false;
        }
    }

    public void TurnLeft(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            Debug.Log("turning left");
            turningLeft = true;
        } 
        else if (ctx.canceled) {
            Debug.Log("stopped turning left");
            turningLeft = false;
        }
    }

    public void TurnRight(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            Debug.Log("turning right");
            turningRight = true;
        } 
        else if (ctx.canceled) {
            Debug.Log("stopped turning right");
            turningRight = false;
        }
    }

    private void Start()
    {
       
        sphereRB.transform.parent = null;
    }

    private void Update()
    {
        //speedInput = Input.GetAxis("Vertical");
        if (accelerate)
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
        else if (braking)
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

        float leftInput, rightInput;

        if(turningLeft) {
            leftInput = -1;
        } else {
            leftInput = 0;
        }

        if (turningRight) {
            rightInput = 1;
        } else {
            rightInput = 0;
        }

        turnInput = leftInput + rightInput;

        //turnInput = Input.GetAxis("Horizontal");
        turnInput = turnInput * (speed / maxSpeed);

        float latSpeed = 0;
        if(turningRight)
        {
            if (turnInput > 0)
                {
                    latSpeed = -CalculateCentripedalForce(speed, 70f, 5000f);
                }
        }
        
        else if (turningLeft)
        {
            if (turnInput < 0)
            {
                latSpeed = CalculateCentripedalForce(speed, 70f, 5000f);
            }
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
