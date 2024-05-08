using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fuelUIScript : MonoBehaviour
{
    private TextMeshProUGUI fuelText;

    // Start is called before the first frame update
    void Start()
    {
        fuelText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFuelText(fuel_tracker playerInventory)
    {
        fuelText.text = playerInventory.NumberOffuel.ToString();
    }
}
