using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float pitchIncreaseRate = 0.1f;
    public float pitchDecreaseRate = 0.1f;
    public float maxPitch = 2.0f;

    private Rigidbody2D rb;
    private float currentPitch = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float currentSpeed = rb.velocity.magnitude;
        if (currentSpeed > 0.1f)
        {
            // Accelerating
            currentPitch = Mathf.Min(currentPitch + pitchIncreaseRate * Time.deltaTime, maxPitch);
        }
        else if (currentSpeed < -0.1f)
        {
            // Decelerating
            currentPitch = Mathf.Max(currentPitch - pitchDecreaseRate * Time.deltaTime, 0.0f);
        }
        else
        {
            // Stopped
            currentPitch = 1.0f;
        }

        audioSource.pitch = currentPitch;
        if (currentPitch > 0.0f && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (currentPitch == 0.0f)
        {
            audioSource.Stop();
        }
    }
}
