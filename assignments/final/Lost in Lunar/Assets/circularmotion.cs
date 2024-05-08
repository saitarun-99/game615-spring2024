using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circularmotion : MonoBehaviour
{
    public float radius = 5.0f; // Radius of the circle
    public float speed = 1.0f; // Speed of orbit
    public float rotationSpeed = 50.0f; // Speed of self-rotation in degrees per second

    private Vector3 centerPosition; // Center of the circle
    private float angle; // Current angle of rotation

    void Start()
    {
        centerPosition = transform.position; // Set center position
    }

    void Update()
    {
        // Handle orbit around the center
        angle += speed * Time.deltaTime; // Increment the angle based on speed and time
        float x = Mathf.Cos(angle) * radius; // Calculate x position
        float z = Mathf.Sin(angle) * radius; // Calculate z position
        transform.position = new Vector3(centerPosition.x + x, centerPosition.y, centerPosition.z + z); // Update position

        // Handle self-rotation
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // Rotate around y-axis
    }
}
