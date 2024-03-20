using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    float yVelocity = 0;
    float gravity = -19.8f;
    float jumpForce = 10f;
    float rocketForce = 5f; // Adjust as needed
    float maxRocketFuel = 100f; // Adjust as needed
    float rocketDuration = 2f; // Adjust as needed
    float currentRocketFuel;
    float rocketTimer;
    bool isJumping;
    bool isRocketing;
    int airJumpsLeft = 2; // Adjust as needed
    int totalRocketUses = 10; // Adjust as needed
    int remainingRocketUses;
    float[] airJumpForce = { 5f, 3f }; // Adjust as needed
    float maxHeight = 20f; // Adjust as needed

    public float speed = 4.0f;
    public Slider rocketUsesSlider;

    private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        currentRocketFuel = maxRocketFuel;
        remainingRocketUses = totalRocketUses;
        UpdateRocketUsesUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle turning left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0f, -90f, 0f));

        // Handle turning right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(new Vector3(0f, 90f, 0f));

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && (myCharacterController.isGrounded || airJumpsLeft > 0))
        {
            if (!myCharacterController.isGrounded && airJumpsLeft > 0)
            {
                airJumpsLeft--;
                yVelocity = airJumpForce[2 - airJumpsLeft];
            }
            else
            {
                yVelocity = jumpForce;
            }
            isJumping = true;
        }

        // Handle rocketing
        if (Input.GetKey(KeyCode.R) && currentRocketFuel > 0 && !myCharacterController.isGrounded)
        {
            if (rocketTimer <= 0 && remainingRocketUses > 0)
            {
                rocketTimer = rocketDuration;
                isRocketing = true;
                currentRocketFuel = maxRocketFuel;
                remainingRocketUses--;
                UpdateRocketUsesUI();
            }
        }

        if (isRocketing)
        {
            if (currentRocketFuel > 0 && rocketTimer > 0)
            {
                yVelocity = rocketForce;
                currentRocketFuel -= Time.deltaTime; // Decrease fuel over time
                rocketTimer -= Time.deltaTime;

                // Limit the player's maximum height while using the rocket pack
                if (transform.position.y > maxHeight)
                {
                    isRocketing = false;
                }
            }
            else
            {
                isRocketing = false;
            }
        }

        // Apply gravity
        if (!myCharacterController.isGrounded && !isRocketing)
        {
            yVelocity += gravity * Time.deltaTime;
        }
        else
        {
            if (yVelocity < 0)
            {
                yVelocity = -2f;
                isJumping = false;
                airJumpsLeft = 2; // Reset air jumps
            }
        }

        Vector3 moveDirection = transform.forward * speed;
        moveDirection.y = yVelocity;

        myCharacterController.Move(moveDirection * Time.deltaTime);
    }

    void UpdateRocketUsesUI()
    {
        if (rocketUsesSlider != null)
        {
            rocketUsesSlider.value = (float)remainingRocketUses / totalRocketUses;
        }
    }
}
