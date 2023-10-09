using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed at which the platform moves.
    public float moveDistance = 5.0f; // Distance the platform moves in either direction.

    private Vector3 startPosition;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (movingRight)
        {
            newPosition.x += moveSpeed * Time.deltaTime;
            if (newPosition.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            newPosition.x -= moveSpeed * Time.deltaTime;
            if (newPosition.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }

        // Update the platform's position.
        transform.position = newPosition;
    }
}
