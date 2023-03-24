using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController1 : MonoBehaviour
{

    public Rigidbody sphereRB;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = sphereRB.transform.position;
    }
}
