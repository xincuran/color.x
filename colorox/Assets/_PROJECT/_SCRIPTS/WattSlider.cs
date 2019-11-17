using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WattSlider : MonoBehaviour {

    //[HideInInspector]
    public float totalChange;

    private Slider slider;
    private StoredEnergy wattChild;
    
    float oldValue;
    float defaultPosition;

    private void Start()
    {
        slider = GetComponent<Slider>();
        oldValue = slider.value;

        wattChild = transform.Find("Handle Slide Area").Find("Watt").GetComponent<StoredEnergy>();
        wattChild.capacity = GetComponent<StoredEnergy>().capacity;
        wattChild.energyToReduce = GetComponent<StoredEnergy>().energyToReduce;
    }

    public void CalculateChange()
    {
        float currentValue = slider.value;
        float change = Mathf.Abs(currentValue - oldValue);
        oldValue = currentValue;

        totalChange += change;
        GetComponentInChildren<Generator>().GetSliderChange(totalChange);
    }

    public void SetDefaultPosition(float _value)
    {
        slider = GetComponent<Slider>();
        defaultPosition = _value;
        slider.value = _value;
        oldValue = slider.value;
    }

    public float GetDefaultPosition()
    {
        return defaultPosition;
    }
}
