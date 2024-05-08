using UnityEngine;
using UnityEngine.Events;

public class fuel_tracker : MonoBehaviour
{
    public int NumberOffuel { get; private set; }
    //this script is for attaching to the player
    public UnityEvent<fuel_tracker> OnfuelCollected;

    public void fuelCollected()
    {
        NumberOffuel++;
        OnfuelCollected.Invoke(this);
    }
}