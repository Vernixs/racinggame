using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyObject : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 1f; // The speed of the floating effect
    [SerializeField] private float floatAmount = 1f; // The amount of distance the object should move up and down
    private Vector3 startPosition; // The starting position of the object

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Use the sin function to create a smooth up and down movement
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        Vector3 newPosition = startPosition + new Vector3(0f, yOffset, 0f);
        transform.position = newPosition;
    }
}
