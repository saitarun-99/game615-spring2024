using UnityEngine;

public class astro_movement : MonoBehaviour
{
    float rotateSpeed = 90f;
    float forwardSpeed = 12f;
    public CharacterController cc;
    //public GameObject cameraObject;
    private float desiredHeight = 2f; // The desired height above the ground
    private float gravity = -9.81f; // You can adjust this as needed

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // Rotate player based on input
        Vector3 amountToRotate = new Vector3(0, hAxis * rotateSpeed * Time.deltaTime, 0);
        transform.Rotate(amountToRotate, Space.Self);

        // Move player forward/backward based on input
        Vector3 move = transform.forward * forwardSpeed * Time.deltaTime * vAxis;
        cc.Move(move);

        // Gravity - apply a consistent downward force
        Vector3 gravityEffect = Vector3.up * gravity * Time.deltaTime;
        cc.Move(gravityEffect);

        // Raycast to adjust height
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            float currentHeight = hit.distance;
            if (currentHeight > desiredHeight)
            {
                // If we're too high, move down
                float adjustment = currentHeight - desiredHeight;
                cc.Move(-Vector3.up * adjustment);
            }
        }
        // Positioning the camera behind and above the plane
        /*Vector3 cameraPosition = transform.position - transform.forward * 10;
        cameraPosition.y = cameraPosition.y + 12;
        cameraObject.transform.position = cameraPosition;
        // Make the camera look at the plane
        cameraObject.transform.LookAt(transform);*/

    }
}
