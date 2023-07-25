using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeFreezeItem : Item
{
    float _deltaTime = 0.01f;
    public float freezeDuration = 5f;
    private Slider slider;
    private float originalValue;
    private float timer = 0;
    private bool isTimeFrozen;

    public void Start()
    {
        slider = GetComponent<Slider>(); //Slider컴포넌트찾아서slider변수에 할당하는 것
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "WingWing")
        {
            TimeFreeze(); //윙윙이랑 충돌하면 이 함수 작동
        }
    }

    private void TimeFreeze()
    {
        if (isTimeFrozen == false) //만약 istumefrozen이 작동할 수 없다면
        {
            isTimeFrozen = true;// 시간을 얼리는 조건 true로 변경
            timer = 0f;
            StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//코루틴 실행

        }

    }

    private IEnumerator ResumeTimeAfterDelay(float delay)//5초 뒤에 작동
    {
        yield return new WaitForSeconds(delay);  //  변경된 부분>> WaitForSeconds를 사용하도록 변경/
                                                //  WaitForSeconds(5.0f); >5초 동안 멈춘 후 메세지 출력(timescale의 영향 받지X)

        originalValue = slider.value;//s.v를 o.v값에 대입>>그러므로 ov는 슬라이더가 멈춰도 이전의 값을 기억하게 됨.

        slider.interactable = false; //아이템 작동 기간 동안 Slider의 상호작용 중지(슬라이더 멈추는 것)
        isTimeFrozen = false; // 변경된 부분>> 시간멈춤을 해제할 때 isTimeFrozen을 false로 변경
        slider.interactable = true;//아이템 작동 후 다시 Slider 상호작용0
    }
}
