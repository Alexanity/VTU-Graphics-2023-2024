using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Accelerate : MonoBehaviour
{
    public Vector3 accelerationDirection = Vector3.down; // Direction of acceleration.
    public float accelerationMagnitude = 1.0f; // Magnitude of acceleration.

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(accelerationDirection * accelerationMagnitude, ForceMode.Acceleration);

    }
}