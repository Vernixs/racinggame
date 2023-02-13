using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearShift : MonoBehaviour
{
    public int currentGear = 1;
    public int[] gearRatios;
    private int maxGears;
    private float engineRPM = 0.0f;

    private void Start()
    {
        maxGears = gearRatios.Length;
    }

    private void Update()
    {
        engineRPM = GetEngineRPM();
        ShiftGears();
    }

    private float GetEngineRPM()
    {
        // Replace this with code that returns the current engine RPM
        // You can get this value from a car controller or from a physics simulation
        return 0.0f;
    }

    private void ShiftGears()
    {
        // Shift to the next gear if the engine RPM is too high for the current gear
        if (engineRPM > 3000.0f)
        {
            currentGear++;
            if (currentGear > maxGears - 1)
            {
                currentGear = maxGears - 1;
            }
        }

        // Shift to the previous gear if the engine RPM is too low for the current gear
        if (engineRPM < 1500.0f)
        {
            currentGear--;
            if (currentGear < 0)
            {
                currentGear = 0;
            }
        }
    }
}
