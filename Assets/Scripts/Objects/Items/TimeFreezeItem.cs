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
        slider = GetComponent<Slider>(); //Slider������Ʈã�Ƽ�slider������ �Ҵ��ϴ� ��
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "WingWing")
        {
            TimeFreeze(); //�����̶� �浹�ϸ� �� �Լ� �۵�
        }
    }

    private void TimeFreeze()
    {
        if (isTimeFrozen == false) //���� istumefrozen�� �۵��� �� ���ٸ�
        {
            isTimeFrozen = true;// �ð��� �󸮴� ���� true�� ����
            timer = 0f;
            StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//�ڷ�ƾ ����

        }

    }

    private IEnumerator ResumeTimeAfterDelay(float delay)//5�� �ڿ� �۵�
    {
        yield return new WaitForSeconds(delay);  //  ����� �κ�>> WaitForSeconds�� ����ϵ��� ����/
                                                //  WaitForSeconds(5.0f); >5�� ���� ���� �� �޼��� ���(timescale�� ���� ����X)

        originalValue = slider.value;//s.v�� o.v���� ����>>�׷��Ƿ� ov�� �����̴��� ���絵 ������ ���� ����ϰ� ��.

        slider.interactable = false; //������ �۵� �Ⱓ ���� Slider�� ��ȣ�ۿ� ����(�����̴� ���ߴ� ��)
        isTimeFrozen = false; // ����� �κ�>> �ð������� ������ �� isTimeFrozen�� false�� ����
        slider.interactable = true;//������ �۵� �� �ٽ� Slider ��ȣ�ۿ�0
    }
}
