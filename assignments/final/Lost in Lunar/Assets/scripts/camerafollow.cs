/*using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player's transform here in the Unity Editor
    public float distance = 10.0f; // Distance behind the target
    public float height = 8.0f; // Height above the target

    void LateUpdate()
    {
        if (!target) return; // If no target is assigned, do nothing

        // Calculate the desired position
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = desiredPosition;

        // Always look at the target
        transform.LookAt(target);
    }
}
*/