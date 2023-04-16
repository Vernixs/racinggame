using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXOnCollision : MonoBehaviour
{
    public VisualEffect vfxPrefab;     // VFX graph prefab to play on collision
    public string collisionTag;        // tag of objects to collide with

    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with object with specified tag
        if (collision.gameObject.CompareTag(collisionTag))
        {
            // Instantiate VFX graph prefab and play it
            VisualEffect vfxInstance = Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            vfxInstance.Play();
        }
    }
}

