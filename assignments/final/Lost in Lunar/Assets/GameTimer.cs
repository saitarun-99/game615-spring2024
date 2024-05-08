using UnityEngine;
using TMPro;  // Make sure to include the TextMeshPro namespace if using TMP for UI
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro UI component for displaying the timer
    public craftscript spacecraft; // Reference to the spacecraft control script
    private float timeRemaining = 60f; // Set the countdown time (60 seconds)

    void Update()
    {
        // Countdown the time
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + timeRemaining.ToString("F2") + "s"; // Update the timer on screen with two decimals
        }
        else
        {
            // When the timer reaches zero, display "Game Over!" and disable controls
            timerText.text = "Game Over!";
            if (spacecraft != null)
            {
                spacecraft.EnableControls(false); // Disable spacecraft controls
            }

            // Optional: Here you can also load a game over scene or manage other end-game logic
            // SceneManager.LoadScene("GameOverScene");
        }
    }
}
