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
        //GetComponent<Slider>().value 는 0~1 사잇값입니다 이 이상의 값이 들어가 봐야 최댓값인 1이 됩니다.
        GetComponent<Slider>().value = 1.0f;
        ///
        GameManager.벨런스용_차후삭제필요();
        IDLETIME = Resources.Load<DataFix>("DataFix").TimeSliderDeltatime_시간줄어드는속도;
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

                // 0이상 작아지지 않습니다.
                //currentValue= 0;
                //GameOver Screen 띄우기
                //GetComponent<GameOver>().EnableGameOverMenu();                        //GameOver창 띄우기

                if (!gameOver)
                {
                    GameManager.SoundManager.Play(Define.SFX.GameOver_01);//GameOver효과음
                    GameManager.UIManager.ShowPopupUI<GameOverUI>();

                    gameOver = true;
                   
                }

            }
        }
        
    }


    public void TimeFreeze()
    {
        Debug.Log("TimeFreezeStart");
        if (isTimeFrozen == false) //만약 istumefrozen이 작동할 수 없다면
        {
            StopTimer();
            isTimeFrozen = true;// 시간을 얼리는 조건 true로 변경 
            StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//코루틴 실행

        }

    }

    private IEnumerator ResumeTimeAfterDelay(float delay)//5초 뒤에 작동
    {
        yield return new WaitForSeconds(delay);  //  변경된 부분>> WaitForSeconds를 사용하도록 변경/
                                                 //  WaitForSeconds(5.0f); >5초 동안 멈춘 후 메세지 출력(timescale의 영향 받지X)

        //originalValue = slider.value;//s.v를 o.v값에 대입>>그러므로 ov는 슬라이더가 멈춰도 이전의 값을 기억하게 됨.
        //
        //slider.interactable = false; //아이템 작동 기간 동안 Slider의 상호작용 중지(슬라이더 멈추는 것)
        //isTimeFrozen = false; // 변경된 부분>> 시간멈춤을 해제할 때 isTimeFrozen을 false로 변경
        //slider.interactable = true;//아이템 작동 후 다시 Slider 상호작용0

        ResetSpeed();

        Debug.Log("END TimeFreezeItem ");

    }

   




}