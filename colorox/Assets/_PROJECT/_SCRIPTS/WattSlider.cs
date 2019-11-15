using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WattSlider : MonoBehaviour {

    [HideInInspector]
    public float totalChange;

    private Slider slider;
    
    float oldValue;

    private void Start()
    {
        slider = GetComponent<Slider>();
        oldValue = slider.value;
    }

    public void CalculateChange()
    {
        float currentValue = slider.value;
        float change = Mathf.Abs(currentValue - oldValue);
        oldValue = currentValue;

        totalChange += change;
        GetComponentInChildren<Generator>().GetSliderChange(totalChange);
    }
}
