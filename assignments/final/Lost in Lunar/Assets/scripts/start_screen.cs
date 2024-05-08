using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_screen : MonoBehaviour
{
    public void PlayGame() 
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 1);
        SceneManager.LoadScene(1);
    }

    public void FlytheCraft()
    {
        SceneManager.LoadScene(2);
    }
    public void StartScreen()
    {
        SceneManager.LoadScene("Start");
    }

    public void StartScreen1()
    {
        SceneManager.LoadScene("Start1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
