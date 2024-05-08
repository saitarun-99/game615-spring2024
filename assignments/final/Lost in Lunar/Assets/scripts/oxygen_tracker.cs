using UnityEngine;
using UnityEngine.Events;

public class oxygen_tracker : MonoBehaviour
{
    public int NumberOftanks { get; private set; }
//this script is for attaching to the player
    public UnityEvent<oxygen_tracker> OnOxygenCollected;

    public void oxygenCollected()
    {
        NumberOftanks++;
        OnOxygenCollected.Invoke(this);
    }
}