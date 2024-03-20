using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leopardscript : MonoBehaviour
{
    public GameObject ElkPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float distanceToMove = 675f; // Distance to move per second
            float movementPerFrame = distanceToMove * Time.deltaTime;
            gameObject.transform.position += gameObject.transform.forward * movementPerFrame;
        }
    }

    /*private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("playa"))
            {
                Debug.Log(other.gameObject.name);
                Renderer rend = gameObject.GetComponent<Renderer>();
                rend.material.color = Color.green;

                for (int i = 0; i < 200; i++)
                {
                    GameObject confetto = Instantiate(ElkPrefab, gameObject.transform.position, Quaternion.identity);
                    confetto.transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                    Rigidbody confettoRB = confetto.GetComponent<Rigidbody>();
                    confettoRB.AddForce(confetto.transform.forward * Random.Range(10, 1000));
                }

                Destroy(gameObject);

            }
        }*/

    }

