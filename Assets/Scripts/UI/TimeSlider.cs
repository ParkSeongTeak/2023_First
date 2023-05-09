using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeSlider : MonoBehaviour
{
    public float maxSliderValue = 10f;
    void Start()
    {
        // Set the starting value of the Slider to match the maximum value
        GetComponent<Slider>().value = maxSliderValue;
    }
    void Update()
    {
        // Get the current value of the slider
        float currentValue = GetComponent<Slider>().value;

        // If the slider value is greater than 0, decrease it by 1 every second
        if (currentValue > 0)
        {
            currentValue -= Time.deltaTime;
            // Make sure the value does not go below 0
            currentValue = Mathf.Max(currentValue, 0f);
            // Set the new value of the slider
            GetComponent<Slider>().value = currentValue;
        }
    }
}