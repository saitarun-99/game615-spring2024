using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] private GameObject snowballPrefab;
    bool canThrow = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canThrow) { 
        if (Input.GetKeyDown(KeyCode.Space))

        {
            StartCoroutine(Throw());
        }
    }
    }

    IEnumerator Throw()
    {
        canThrow = false;
        GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation);
        Rigidbody rb = snowball.GetComponent<Rigidbody>();  
        rb.AddForce(transform.forward*1000);
        yield return new WaitForSeconds(1f);
        canThrow = true;
    }
}
