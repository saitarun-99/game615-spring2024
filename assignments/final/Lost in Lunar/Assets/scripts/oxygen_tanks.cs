using UnityEngine;

public class oxygen_tanks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        oxygen_tracker playerInventory = other.GetComponent<oxygen_tracker>();

        if (playerInventory != null)
        {
            playerInventory.oxygenCollected();
            gameObject.SetActive(false);
        }
    }
}