using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadLight : MonoBehaviour
{
    private static GameObject lightGameObject;

    void Awake()
    {
        // Check if the light game object already exists
        if (lightGameObject == null)
        {
            // If it doesn't, create a new game object to hold the light source
            lightGameObject = new GameObject("Persistent Light");
            DontDestroyOnLoad(lightGameObject);

            // Attach a light component to the game object
            Light lightComponent = lightGameObject.AddComponent<Light>();
            lightComponent.type = LightType.Directional;
            lightComponent.intensity = 0.01f;
            lightComponent.color = Color.white;
        }
        else
        {
            // If the light game object already exists, destroy this duplicate game object
            Destroy(gameObject);
        }
    }
}
