using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newcheckpoint : MonoBehaviour
{
    [Header("Checkpoints")]
    public GameObject start;
    public GameObject end;
    public GameObject[] checkpoints;

    public float laps = 1;

    float currentCheckpoint;
    float currentLap;
    bool started;
    bool finished;

    private void Start()
    {
        currentCheckpoint = 0;
        currentLap = 1;

        started = false;
        finished = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Checkpoint"))
        {
            Debug.Log("checking");
            GameObject thisCheckpoint = other.gameObject;
            
            if (thisCheckpoint == start && !started)
            {
                Debug.Log("Started");
                started = true;
            }
            else if (thisCheckpoint == end && started)
            {
                if (currentLap == laps)
                {
                    if (currentCheckpoint == checkpoints.Length)
                    {
                        finished = true;
                        //started= false;
                        Debug.Log("Finished");
                    }
                }
            }
            else if (currentLap < laps)
            {
                if (currentCheckpoint == checkpoints.Length)
                {
                    currentLap++;
                    currentCheckpoint = 0;
                    Debug.Log("new lap");
                }
            }

            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (finished)
                {
                    SceneManager.LoadScene(1);
                }
                if (thisCheckpoint == checkpoints[i] && i == currentCheckpoint)
                {
                    Debug.Log("correct checkpoint");
                    currentCheckpoint++;
                }
            }
        }
    }

}
