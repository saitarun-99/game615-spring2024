using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIscript : MonoBehaviour
{
    private TextMeshProUGUI oxygenText;

    // Start is called before the first frame update
    void Start()
    {
        oxygenText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateOxygenText(oxygen_tracker playerInventory)
    {
        oxygenText.text = playerInventory.NumberOftanks.ToString();
    }
}
