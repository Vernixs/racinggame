using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearTireGrip : MonoBehaviour
{
    public WheelCollider wheelCollider;

    private void Start()
    {
        WheelFrictionCurve forwardFriction = wheelCollider.forwardFriction;
        forwardFriction.stiffness = 0f;
        wheelCollider.forwardFriction = forwardFriction;
    }
}
