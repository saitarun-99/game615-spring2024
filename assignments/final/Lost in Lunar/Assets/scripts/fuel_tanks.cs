using UnityEngine;

public class fuel_tanks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        fuel_tracker playerInventory = other.GetComponent<fuel_tracker>();

        if (playerInventory != null)
        {
            playerInventory.fuelCollected();
            gameObject.SetActive(false);
        }
    }
}