using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacingTimer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isTimerRunning;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            float timeElapsed = Time.time - startTime;
            string minutes = Mathf.Floor(timeElapsed / 60).ToString("00");
            string seconds = (timeElapsed % 60).ToString("00");
            string milliseconds = ((timeElapsed * 100) % 100).ToString("00");
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        timerText.text = "00:00:00";
    }
}
