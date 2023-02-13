using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log(SlipAngleRear(100f, 1f, Vector3.up, Vector3.down));
    }

   
    float SlipAngleRear(float velocityLatitude, float velocityLongitude, Vector3 omega, Vector3 b)
    {
        return Mathf.Atan(velocityLatitude + Vector3.Dot(omega, b) / velocityLongitude);

    }
}
