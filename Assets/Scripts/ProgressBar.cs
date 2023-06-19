using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float maxValue;
    public float currentValue;
    public Image Bar;


    public void CurrentValueUpdate(float value)
    {
        currentValue = value;
        Update();
    }
    void Update()
    {
        float fillAmount = currentValue / maxValue;
        Bar.fillAmount = fillAmount;
    }

}
