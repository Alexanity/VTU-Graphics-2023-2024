using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // The sensitivity of the mouse
    public float mouseSensitivity = 100f;

    // Reference to the FirstPersonPlayer
    public Transform playerBody;

    // Our X axis that we're using for moving the camera Vertically
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the Aixs we want to move
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Time.deltaTime - makes the game run more smoothly
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Every frame we decrease the xRotation based on MouseY | we're using -= because += has the rotation flipped
        xRotation -= mouseY;
        // This way we're sure that we won't overrotate
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        // Applying the rotation |Quaternion is used for rotation
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

        // Rotates *around* the Y axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
