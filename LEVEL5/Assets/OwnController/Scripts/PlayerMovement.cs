using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to the character Controller
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // movement speed
    public float speed = 12f;

    public float gravity = -9.81f;

    public float jumpHeight = 3f;

    // Gradually picking up speed as the player falls down
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        // Creates a little sphere checking if it's colliding with anything, if yes then it's true, if not then it's false
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If we're on the ground -> reset the velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        // Input
        float x = Input.GetAxis("Horizontal"); // A&D   
        float z = Input.GetAxis("Vertical");   // W&S

// ------------------------------------------------------------------------------
        // Taking the input and putting it in the direction that we want to move

        //Vector3 move = new Vector3 (x,0f,z); - this is globad movement, the player will be moving in the same direction no matter where the camera is facing

        Vector3 move = transform.right * x + transform.forward * z; // movement based on where we're looking at

        controller.Move(move * speed * Time.deltaTime);

        // Adding jump - "Jump" is another ready to use input
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // building up the velocity
        velocity.y += gravity * Time.deltaTime;
        // moving the controller downwards
        controller.Move(velocity * Time.deltaTime);
    }
}
