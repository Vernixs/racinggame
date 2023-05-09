using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpointsingle : MonoBehaviour
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
    

    //private float currentLapTime;
    //private float bestLapTime;
    //float bestLap;

    private void Start()
    {
        currentCheckpoint = 0;
        currentLap = 1;

        started = false;
        finished = false;

        //currentLapTime = 0;
       // bestLapTime = 0;
       // bestLap = 0;
    }

    private void Update()
    {
       /* if (started && !finished) 
        {
            //currentLapTime += Time.deltaTime;

            if (bestLap == 0)
            {
                bestLap = 1;
            }
        }

        if (started)
        {
            if(bestLap == currentLap)
            {
                bestLapTime = currentLapTime;
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
     if(other.CompareTag("Checkpoint"))
        {
            GameObject thisCheckpoint = other.gameObject;

            if(thisCheckpoint == start && !started)
            {
                Debug.Log("Started");
                started = true;
            }
            else if(thisCheckpoint == end && started) 
            {
                if(currentLap == laps)
                {
                    if(currentCheckpoint == checkpoints.Length)
                    { 
                        /*if(currentLapTime < bestLapTime)
                        {
                            bestLap = currentLap;
                        }*/
                        finished = true;
                        started= false;
                        Debug.Log("Finished");
                    }
                }
            }
            else if (currentLap < laps)
            {
                if (currentCheckpoint == checkpoints.Length)
                {
                    /*if(currentLapTime < bestLapTime)
                    {
                        bestLap = currentLap;
                        bestLapTime = currentLapTime;
                    }*/

                    currentLap++;
                    currentCheckpoint = 0;
                    //currentLapTime = 0;
                    Debug.Log("new lap");
                }
            }

            for(int i = 0; i < checkpoints.Length; i++)
            {
                if (finished)
                {
                    SceneManager.LoadScene(1);
                    //return;
                }
                if(thisCheckpoint == checkpoints[i] && i == currentCheckpoint)
                {
                    Debug.Log("correct checkpoint");
                    currentCheckpoint++;
                }
            }
        }
    }

}
