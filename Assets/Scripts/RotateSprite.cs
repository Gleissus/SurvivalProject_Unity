using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        // Rotates the sprite 
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
