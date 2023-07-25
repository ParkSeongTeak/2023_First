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
        //base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "WingWing")
        {
            //TimeFreeze(); //�����̶� �浹�ϸ� �� �Լ� �۵�
            
            GameUI.Instance.TimeFreeze();
            Destroy(gameObject);


        }
    }

    
}
