using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; // Direction in which the cube will move.
    public float moveSpeed = 5.0f; // Speed at which the cube moves.

    void Start()
    {   
    }
    // Update is called once per frame
    void Update()
    {
        // Calculate the new position based on the specified direction and speed.
        Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

        // Update the cube's position.
        transform.position = newPosition;
    }
}
