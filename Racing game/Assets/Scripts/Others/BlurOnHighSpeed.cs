using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurOnHighSpeed : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    public float blurAmount = 0.1f;
    public float maxBlur = 0.3f;
    public Material blurMaterial;

    private Rigidbody rb;
    private float currentSpeed;
    private float blurValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentSpeed = rb.velocity.magnitude;

        if (currentSpeed >= maxSpeed)
        {
            blurValue = Mathf.Lerp(blurValue, maxBlur, Time.deltaTime);
        }
        else
        {
            blurValue = Mathf.Lerp(blurValue, 0.0f, Time.deltaTime);
        }

        blurMaterial.SetFloat("_BlurValue", blurValue * blurAmount);
    }
}
