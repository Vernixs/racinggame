using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lapcounter1 : MonoBehaviour
{
    public float numLaps = 3f;
    public Text LapNumberText;
    public Text TotalLapsText;
    public int TotalLaps = 3;
    public static int LapNumber;

    private void Start()
    {
        LapNumberText.text = "0";
        TotalLapsText.text = "/" + TotalLaps.ToString();
    }

    private void Update()
    {
        LapNumberText.text = LapNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Player"))
        {
            LapNumber++;
        }
    }
}
