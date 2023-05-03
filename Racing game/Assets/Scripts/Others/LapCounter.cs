using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public int numLaps = 3; // Number of laps to complete
    public Text lapText; // Text component to display lap count

    private int currentLap = 1; // Current lap count

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("1Time");
            if (currentLap <= numLaps)
            {
                currentLap++;
                lapText.text = currentLap.ToString() + "0/3" + numLaps.ToString();
            }
        }
    }
}
