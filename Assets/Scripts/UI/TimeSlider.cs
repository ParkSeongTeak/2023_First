using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeSlider : MonoBehaviour

{
    [SerializeField]
    float _deltaTime = 0.01f;
    void Start()
    {
        //GetComponent<Slider>().value 는 0~1 사잇값입니다 이 이상의 값이 들어가 봐야 최댓값인 1이 됩니다.
        GetComponent<Slider>().value = 1.0f;
    }
    void Update()
    {
        // Get the current value of the slider
        //GetComponent<Slider>().value;
        GetComponent<Slider>().value -= _deltaTime * Time.deltaTime;

        // If the slider value is greater than 0, decrease it by 1 every second
        if (GetComponent<Slider>().value > 0)
        {
            GetComponent<GameOver>().DisableGameOverMenu();
            // Set the new value of the slider
        }
        else
        {
            // 0이상 작아지지 않습니다.
            //currentValue= 0;
            //GameOver Screen 띄우기
            GetComponent<GameOver>().EnableGameOverMenu();                        //GameOver창 띄우기
        }
    }
}