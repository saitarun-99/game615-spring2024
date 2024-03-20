using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class Planescript : MonoBehaviour
{
    int score = 0;
    public float forwardspeed = 5f;
    public float rotateSpeed = 50;
    public GameObject cameraObject;
    public GameObject projectilePrefab;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        //Debug.Log(Time.deltaTime);
        Vector3 amountToRotate = new Vector3(0, 0, 0);
        // distance=speed x time
        amountToRotate.x = -vAxis * rotateSpeed * Time.deltaTime;
        amountToRotate.z = -hAxis * rotateSpeed * Time.deltaTime;

        transform.Rotate(amountToRotate, Space.Self);

        float fakeGravity = 0.5f;
        forwardspeed = forwardspeed - fakeGravity * transform.forward.y;
        
        
        if (Input.GetKey(KeyCode.B))
        {
            forwardspeed = forwardspeed +50*Time.deltaTime;
        }

        forwardspeed = Mathf.Clamp(forwardspeed, 0, 10);
        Vector3 amountToMove = transform.forward * forwardspeed * Time.deltaTime;
        transform.position = transform.position + amountToMove;

        Vector3 cameraPosition = transform.position - transform.forward * 15;
        cameraPosition.y = cameraPosition.y + 1;
        cameraObject.transform.position = cameraPosition;
        // Make the camera look at the plane
        cameraObject.transform.LookAt(transform);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projObj = Instantiate(projectilePrefab, transform.position + transform.forward * 5, transform.rotation);
            Rigidbody projRB = projObj.GetComponent<Rigidbody>();
            projRB.AddForce(transform.forward * 1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("passing"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
