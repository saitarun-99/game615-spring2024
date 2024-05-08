using UnityEngine;

public class random_roam : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Movement speed of the rover
    public float turnSpeed = 100.0f; // Turning speed of the rover
    public float directionChangeInterval = 3.0f; // How often the rover changes its moving direction

    private float currentDirectionChangeTime;

    void Start()
    {
        currentDirectionChangeTime = directionChangeInterval;
    }

    void Update()
    {
        // Countdown to direction change
        currentDirectionChangeTime -= Time.deltaTime;

        // When the countdown reaches zero, change the direction
        if (currentDirectionChangeTime <= 0)
        {
            ChangeDirection();
            currentDirectionChangeTime = directionChangeInterval;
        }

        // Move forward in the current direction
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        // Randomly change the direction by setting a new rotation around the y-axis
        float newRotation = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, newRotation, 0);
    }
}
