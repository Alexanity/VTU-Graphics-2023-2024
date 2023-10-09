using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoPlatform : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation.
    public float rotationSpeed = 45.0f; // Speed of rotation in degrees per second.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the platform continuously.
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
