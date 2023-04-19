using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keymapping : MonoBehaviour
{
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            Debug.Log("Detected key code: " + e.keyCode);
        }
    }

}
