using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapCounter : MonoBehaviour
{
    public int numLaps = 3; // Number of laps to complete
    public Text lapText; // Text component to display lap count

    private int currentLap = 1; // Current lap count

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("1Time");
            if (currentLap != numLaps)
            {
                Debug.Log("next lap");
                currentLap++;
                lapText.text = currentLap.ToString() + "0/3" + numLaps.ToString();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

}


