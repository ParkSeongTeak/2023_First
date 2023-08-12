using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeSlider : MonoBehaviour

{
    //const float IDLETIME = 0.1f;
    float IDLETIME = 0.1f;
    float _deltaTime;
    public float freezeDuration = 5f;
    private bool isTimeFrozen;

    private bool gameOver = false;
    private GameObject player;


    void Start()
    {
        //GetComponent<Slider>().value �� 0~1 ���հ��Դϴ� �� �̻��� ���� �� ���� �ִ��� 1�� �˴ϴ�.
        GetComponent<Slider>().value = 1.0f;
        ///
        GameManager.��������_���Ļ����ʿ�();
        IDLETIME = Resources.Load<DataFix>("DataFix").TimeSliderDeltatime_�ð��پ��¼ӵ�;
        ///

        _deltaTime = IDLETIME;

        gameOver = false;
        player = GameObject.FindWithTag("WingWing");
    }

    public void StopTimer()
    {
        _deltaTime = 0f;
    }
    
    public void ResetSpeed()
    {
        _deltaTime = IDLETIME;
    }
    public void PlusTime(float plustime)
    {
        GetComponent<Slider>().value += plustime;
    }
    


    void Update()
    {
        if (player != null)
        {
            // Get the current value of the slider
            //GetComponent<Slider>().value;
            GetComponent<Slider>().value -= _deltaTime * Time.deltaTime;

            // If the slider value is greater than 0, decrease it by 1 every second
            if (GetComponent<Slider>().value > 0)
            {

            }
            else
            {

                // 0�̻� �۾����� �ʽ��ϴ�.
                //currentValue= 0;
                //GameOver Screen ����
                //GetComponent<GameOver>().EnableGameOverMenu();                        //GameOverâ ����

                if (!gameOver)
                {
                    GameManager.SoundManager.Play(Define.SFX.GameOver_01);//GameOverȿ����
                    GameManager.UIManager.ShowPopupUI<GameOverUI>();

                    gameOver = true;
                   
                }

            }
        }
        
    }


    public void TimeFreeze()
    {
        Debug.Log("TimeFreezeStart");
        if (isTimeFrozen == false) //���� istumefrozen�� �۵��� �� ���ٸ�
        {
            StopTimer();
            isTimeFrozen = true;// �ð��� �󸮴� ���� true�� ���� 
            StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//�ڷ�ƾ ����

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

        ResetSpeed();

        Debug.Log("END TimeFreezeItem ");

    }

   




}