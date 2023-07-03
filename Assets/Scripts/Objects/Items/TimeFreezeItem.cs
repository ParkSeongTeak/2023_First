using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TimeFreezeItem : MonoBehaviour
{
    public float timeSlider = 0f;
    public bool stopTimeSlider;
    public float stopDuration = 5f; // Duration in seconds to stop the time slider
    float _deltaTime = 0.01f;
    void Start()
    {
        // Find the object you want to tag
        GameObject objToTag = GameObject.Find("TimeFreezeItem");

        // Check if the object exists
        if (objToTag != null)
        {
            // Assign the desired tag
            objToTag.tag = "stopTimeSlider";
        }
        else
        {
            Debug.LogWarning("Object not found.");
        }
    }
    private void Update()
        
    {
        if (stopTimeSlider == false) 

        {
            Time.timeScale = 0f;
            stopDuration = 5f;// Pause the game
            stopTimeSlider = true;
        }

        else if(stopTimeSlider == true)

        {
            Time.timeScale = 1f; // Resume the game
            GetComponent<Slider>().value -= _deltaTime * Time.deltaTime;
            stopTimeSlider = false;
        }

    }
    

}




       
        