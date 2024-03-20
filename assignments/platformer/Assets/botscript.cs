using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class botscript : MonoBehaviour
{
    public GameObject target;
    float speed = 10;

    NavMeshAgent nma;
    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");

        Animator animator = gameObject.GetComponentInChildren<Animator>();
        animator.Play("hover", 0, Random.value);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vecToTarget = target.transform.position - transform.position;
        
        vecToTarget.Normalize();
        
        vecToTarget *= speed;

        vecToTarget *= Time.deltaTime;

        transform.position += vecToTarget;
        //write in on line


        //nma.destination;
    }
}
