using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class earth_scene : MonoBehaviour
{     void OnTriggerEnter(Collider other)

    {
        SceneManager.LoadScene(0); 
    }
}
