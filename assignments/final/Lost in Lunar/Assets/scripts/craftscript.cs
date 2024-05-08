using UnityEngine;
using System.Collections;

public class craftscript : MonoBehaviour
{
    public float defaultForwardSpeed = 10.0f; // Default forward speed
    public float boostSpeed = 30.0f; // Boost speed
    public float verticalSpeed = 5.0f; // Speed for moving up and down
    public float turnSpeed = 75.0f; // Speed for turning

    private Rigidbody rb; // Rigidbody component for physics-based movement
    private bool isBoosting = false; // State flag for boosting
    private bool controlsEnabled = true; // Flag to control whether input should be processed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!controlsEnabled)
        {
            rb.velocity = Vector3.zero; // Stop movement when controls are disabled
            return;
        }

        if (isBoosting)
        {
            Boost();
        }
        else
        {
            MoveForward();
        }

        AdjustVertical();
        Turn();
    }

    void Update()
    {
        if (!controlsEnabled) return; // Ignore input when controls are disabled

        // Check boost key in Update for more responsive input handling
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBoosting = true;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            isBoosting = false;
        }
    }

    void MoveForward()
    {
        rb.velocity = transform.forward * defaultForwardSpeed + new Vector3(0, rb.velocity.y, 0);
    }

    void Boost()
    {
        rb.velocity = transform.forward * boostSpeed + new Vector3(0, rb.velocity.y, 0);
    }

    void AdjustVertical()
    {
        float verticalInput = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ? 1 :
                              Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

        rb.velocity = new Vector3(rb.velocity.x, verticalInput * verticalSpeed, rb.velocity.z);
    }

    void Turn()
    {
        float turnInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, turnInput * turnSpeed * Time.deltaTime, 0);
    }

    public void EnableControls(bool enable)
    {
        controlsEnabled = enable;
        if (!enable)
        {
            isBoosting = false; // Make sure boosting stops when controls are disabled
        }
    }
}
