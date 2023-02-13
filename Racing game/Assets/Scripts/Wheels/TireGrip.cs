using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireGrip : MonoBehaviour
{
    public WheelCollider wheelCollider;
    public float grip = 1f;

    private void Start()
    {
        WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
        sidewaysFriction.stiffness = grip;
        wheelCollider.sidewaysFriction = sidewaysFriction;
    }

    private void Update()
    {
        WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
        sidewaysFriction.stiffness = grip;
        wheelCollider.sidewaysFriction = sidewaysFriction;
    }
}
