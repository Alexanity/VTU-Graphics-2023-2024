using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyInteraction : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //gets called whenever the character controller collides with anything
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // RB attached to the object we've collided with
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            // minus the position of the character from the position of the obstacle ( find our desired direction of pushing)
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            // removing the y element so that we only push on the x,z plane
            forceDirection.y = 0f;
            // normalizing the direction vector so it has a magnitude of one
            forceDirection.Normalize();

            // apply force at a specific position | position of the character -> force is applied from where the character is standing
            rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse); // Impulse - force is applied instantly
        }
    }
}
