using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;
    public GameObject minuteDisplay;
    public GameObject secondDisplay;
    public GameObject milliDisplay;

    private void OnTriggerEnter()
    {
        if(lapTimeManager.SecondCount <= 9)
        {
            secondDisplay.GetComponent<Text>().text = "0" + lapTimeManager.SecondCount + ".";
        }
        else
        {
            secondDisplay.GetComponent<Text>().text = "" + lapTimeManager.SecondCount + ".";
        }

        if (lapTimeManager.MinuteCount <= 9)
        {
            minuteDisplay.GetComponent<Text>().text = "0" + lapTimeManager.MinuteCount + ".";
        }
        else
        {
            minuteDisplay.GetComponent<Text>().text = "" + lapTimeManager.MinuteCount + ".";
        }

        milliDisplay.GetComponent<Text>().text = "" + lapTimeManager.MilliCount;

        lapTimeManager.MinuteCount = 0;
        lapTimeManager.SecondCount = 0;
        lapTimeManager.MilliCount = 0;

        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}
