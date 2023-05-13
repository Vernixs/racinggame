using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private Image speedometerImage;
    [SerializeField] private Image[] speedometerImages;
    [SerializeField] private float[] speedThresholds;
    [SerializeField] private Rigidbody carRigidbody;
    [SerializeField] private Text speedText;

    private int currentSpeedometerIndex = -1;

    private void Update()
    {
        // Calculate the current speed of the car
        float carSpeed = carRigidbody.velocity.magnitude * 2.237f; // Convert from m/s to mph

        // Find the index of the speedometer image to display
        int newSpeedometerIndex = -1;
        for (int i = 0; i < speedThresholds.Length; i++)
        {
            if (carSpeed <= speedThresholds[i])
            {
                newSpeedometerIndex = i;
                break;
            }
        }

        // If the index has changed, update the image
        if (newSpeedometerIndex != currentSpeedometerIndex)
        {
            currentSpeedometerIndex = newSpeedometerIndex;
            if (currentSpeedometerIndex >= 0 && currentSpeedometerIndex < speedometerImages.Length)
            {
                for (int i = 0; i < speedometerImages.Length; i++)
                {
                    if (i <= currentSpeedometerIndex)
                    {
                        speedometerImages[i].enabled = true;
                    }
                    else
                    {
                        speedometerImages[i].enabled = false;
                    }
                }
            }
        }

        // Update speed text
        speedText.text = carSpeed.ToString("0") + " km/hr";
    }
}
