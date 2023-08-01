using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeSlider : MonoBehaviour

{
    //[SerializeField]
    static float _deltaTime = 0.01f;
    public float freezeDuration = 5f;
    private bool isTimeFrozen;
  
    void Start()
    {
        //GetComponent<Slider>().value �� 0~1 ���հ��Դϴ� �� �̻��� ���� �� ���� �ִ��� 1�� �˴ϴ�.
        GetComponent<Slider>().value = 1.0f;
    }

    public static void StopTimer()
    {
        _deltaTime = 0f;
    }
    
    public static void ResetSpeed()
    {
        _deltaTime = 0.01f;
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


    public void TimeFreeze()
    {
        Debug.Log("TimeFreezeStart");
        if (isTimeFrozen == false) //���� istumefrozen�� �۵��� �� ���ٸ�
        {
            StopTimer();
            isTimeFrozen = true;// �ð��� �󸮴� ���� true�� ���� 
            this.StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//�ڷ�ƾ ����

        }

    }

    private IEnumerator ResumeTimeAfterDelay(float delay)//5�� �ڿ� �۵�
    {
        yield return new WaitForSeconds(delay);  //  ����� �κ�>> WaitForSeconds�� ����ϵ��� ����/
                                                 //  WaitForSeconds(5.0f); >5�� ���� ���� �� �޼��� ���(timescale�� ���� ����X)

        //originalValue = slider.value;//s.v�� o.v���� ����>>�׷��Ƿ� ov�� �����̴��� ���絵 ������ ���� ����ϰ� ��.
        //
        //slider.interactable = false; //������ �۵� �Ⱓ ���� Slider�� ��ȣ�ۿ� ����(�����̴� ���ߴ� ��)
        //isTimeFrozen = false; // ����� �κ�>> �ð������� ������ �� isTimeFrozen�� false�� ����
        //slider.interactable = true;//������ �۵� �� �ٽ� Slider ��ȣ�ۿ�0

        TimeSlider.ResetSpeed();

        Debug.Log("END TimeFreezeItem ");

    }

    private void SomeFunction()
    {
        // ���� �����̴��� �� ��������
        float currentValue = TimeSlider.value;

        // �����̴��� 2��(1.0f)�� ���� ������ �����ϱ�
        float newValue = currentValue + 1.0f;
        TimeSlider.value = Mathf.Clamp01(newValue); // �����̴��� ���� 0.0���� 1.0 ���̷� ���ѵ�
    }




}