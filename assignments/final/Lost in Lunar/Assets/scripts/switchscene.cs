using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscene : MonoBehaviour
{
    // Assuming both trackers are attached to the player, they can be set via the inspector or fetched dynamically.
    public fuel_tracker playerFuelTracker;
    public oxygen_tracker playerOxygenTracker;

    private void OnTriggerEnter(Collider other)
    {
        // Fetch the player's fuel and oxygen trackers if not already referenced
        if (playerFuelTracker == null || playerOxygenTracker == null)
        {
            playerFuelTracker = other.GetComponent<fuel_tracker>();
            playerOxygenTracker = other.GetComponent<oxygen_tracker>();
        }

        // Check if both fuel and oxygen conditions are met
        if (playerFuelTracker != null && playerOxygenTracker != null)
        {
            if (playerFuelTracker.NumberOffuel >= 5 && playerOxygenTracker.NumberOftanks >= 10)
            {
                SceneManager.LoadScene(2); // Load the new scene only if both conditions are met
            }
        }
    }
}
