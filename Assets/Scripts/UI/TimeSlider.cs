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
        //GetComponent<Slider>().value �� 0~1 ���հ��Դϴ� �� �̻��� ���� �� ���� �ִ��� 1�� �˴ϴ�.
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
            // 0�̻� �۾����� �ʽ��ϴ�.
            //currentValue= 0;
            //GameOver Screen ����
            GetComponent<GameOver>().EnableGameOverMenu();                        //GameOverâ ����
        }
    }
}