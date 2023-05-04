using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lapcounter1 : MonoBehaviour
{
    public float numLaps = 3f;
    public Text texts;

    float startingLap = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            startingLap += 1;
            texts.text = startingLap.ToString();
        }
    }
}
