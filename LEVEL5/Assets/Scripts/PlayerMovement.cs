using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to the character Controller
    public CharacterController controller;

    // movement speed
    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        // Input
        float x = Input.GetAxis("Horizontal"); // W&S
        float z = Input.GetAxis("Vertical");   // A&D

// ------------------------------------------------------------------------------
        // Taking the input and putting it in the direction that we want to move

        // Vector3 move = new Vector3 (x,0f,z); - this is globad movement, the player will be moving in the same direction no matter where the camera is facing

        Vector3 move = transform.right * x + transform.forward * z; // movement based on where we're looking at

        controller.Move(move * speed * Time.deltaTime);
    }
}
