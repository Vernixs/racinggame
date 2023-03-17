using UnityEngine;
using System.Collections;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

public enum GearState
{
	Neutral,
	Running,
	CheckingChange,
	Changing
};

[ExecuteInEditMode()]
public class CarController : MonoBehaviour {
	public WheelColliders colliders;
	public WheelMeshes wheelMeshes;
	public float gasInput;
	public float steeringInput;
    public float motorPower;
    private float speed;
    private Rigidbody Rigidbodyrb;
    public AnimationCurve steeringCurve;
    public float brakePower;
    public float slipAngle;
    public float brakeInput;

    private void Start()
    {
        Rigidbodyrb= gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        //speed of the car
        speed = Rigidbodyrb.velocity.magnitude;

        // work out the stiffness and damper parameters based on the better spring model
        foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>())
        {
            JointSpring spring = wc.suspensionSpring;

            spring.spring = Mathf.Pow(Mathf.Sqrt(wc.sprungMass) * naturalFrequency, 2);
            spring.damper = 2 * dampingRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);

            wc.suspensionSpring = spring;

            Vector3 wheelRelativeBody = transform.InverseTransformPoint(wc.transform.position);
            float distance = GetComponent<Rigidbody>().centerOfMass.y - wheelRelativeBody.y + wc.radius;

            wc.forceAppPointDistance = distance - forceShift;

            // the following line makes sure the spring force at maximum droop is exactly zero
            if (spring.targetPosition > 0 && setSuspensionDistance)
                wc.suspensionDistance = wc.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
        }

        Motor();
        CheckInput();
        ApplyWheelPositions();
        Steering();
        Brake();
    }

    void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward, Rigidbodyrb.velocity-transform.forward);
        if (slipAngle < 120f)
        {
            if (gasInput < 0 ) 
            {
                brakeInput = Mathf.Abs(gasInput);
                gasInput = 0;
            }
            else
            {
                brakeInput = 0;
            }
        }
        else
        {
            brakeInput = 0;
        }
    }
    void Brake()
    {
        //front wheels
        colliders.FRWheel.brakeTorque = brakeInput * brakePower * 0.7f;
        colliders.FLWheel.brakeTorque = brakeInput * brakePower * 0.7f;

        //back wheels
        colliders.BRWheel.brakeTorque = brakeInput * brakePower * 0.3f;
        colliders.BLWheel.brakeTorque = brakeInput * brakePower * 0.3f;
    }
    void Motor()
    {

        colliders.BRWheel.motorTorque = motorPower * gasInput;
        colliders.BLWheel.motorTorque = motorPower * gasInput;

    }

    void Steering()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        steeringAngle += Vector3.SignedAngle(transform.forward, Rigidbodyrb.velocity + transform.forward, Vector3.up);
        steeringAngle = Mathf.Clamp(steeringAngle, -90, 90);
        colliders.FRWheel.steerAngle = steeringAngle;
        colliders.FLWheel.steerAngle = steeringAngle;
    }
    void ApplyWheelPositions()
    {
        UpdateWheel(colliders.FRWheel, wheelMeshes.FRWheel);
        UpdateWheel(colliders.FLWheel, wheelMeshes.FLWheel);
        UpdateWheel(colliders.BRWheel, wheelMeshes.BRWheel);
        UpdateWheel(colliders.BLWheel, wheelMeshes.BLWheel);
    }
    void UpdateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
		Quaternion quat;
		Vector3 position;
		coll.GetWorldPose(out position, out quat);
		wheelMesh.transform.position = position;
		wheelMesh.transform.rotation = quat;
    }


    [Range(0, 20)]
    public float naturalFrequency = 10;

    [Range(0, 3)]
    public float dampingRatio = 0.8f;

    [Range(-1, 1)]
    public float forceShift = 0.03f;

    public bool setSuspensionDistance = true;

}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider FRWheel;
    public WheelCollider FLWheel;
    public WheelCollider BRWheel;
    public WheelCollider BLWheel;
}
[System.Serializable]
public class WheelMeshes
{
    public MeshRenderer FRWheel;
    public MeshRenderer FLWheel;
    public MeshRenderer BRWheel;
    public MeshRenderer BLWheel;
}