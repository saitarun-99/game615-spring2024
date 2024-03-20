using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
   
{
    public Image fgImage;
    public float meterMax = 100;
    public float meterValue;
    // Start is called before the first frame update
    void Start()
    {
        meterValue = meterMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMeter(float valueChange)
    {
        meterValue = -valueChange;
        fgImage.fillAmount = meterValue/meterMax;
    }

    public void SetMeter(float valueChange)
    {
        meterValue = -valueChange;
        fgImage.fillAmount = meterValue / meterMax;
    }
}
