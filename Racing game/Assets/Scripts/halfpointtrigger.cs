using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfpointtrigger : MonoBehaviour
{
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;

    private void OnTriggerEnter()
    {
        lapCompleteTrig.SetActive(true);
        halfLapTrig.SetActive(false);
    }
}
