using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotatespeed = 90f;
    float forwardspeed = 8f;
    float yVelocity = 0;
    float gravity = -19.8f;
    float jumpforce = 10f;
    // Start is called before the first frame update

    GameObject movingPlatform;
    Vector3 previousPlatformPosition;
    public CharacterController cc;
    public Animator animator;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 amountToRotate = new Vector3(0, 0, 0);
        amountToRotate.y = hAxis * rotatespeed*Time.deltaTime;
        transform.Rotate(amountToRotate, Space.Self);

        if (!cc.isGrounded)
        {
            yVelocity += gravity * Time.deltaTime;

            if(Input.GetKeyUp(KeyCode.Space) && yVelocity>0) {
                yVelocity= 0;
            }
        }
        else
        {
            //we are on ground
            yVelocity = -2;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpforce;
                // Debug.Log("jumping");
            }
        }

        
       // yVelocity += gravity*Time.deltaTime;


        Vector3 amountToMove = transform.forward* forwardspeed*vAxis;
        if (amountToMove.magnitude > 0)
        {
            animator.SetBool("walk",true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        
        amountToMove.y = yVelocity;
        amountToMove *= Time.deltaTime;

        if (movingPlatform != null)
        {
            Vector3 distancePlatformMoved = movingPlatform.transform.position - previousPlatformPosition;
            amountToMove += distancePlatformMoved;
            previousPlatformPosition = movingPlatform.transform.position;
        }

        cc.Move(amountToMove);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("moving_platform"))
        {
            previousPlatformPosition = other.transform.parent.position;
            movingPlatform = other.transform.parent.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("moving_platform"))
        {
            movingPlatform = null;
        }
    }
}
