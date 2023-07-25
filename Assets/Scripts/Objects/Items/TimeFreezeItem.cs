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
        //base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "WingWing")
        {
            //TimeFreeze(); //윙윙이랑 충돌하면 이 함수 작동
            
            GameUI.Instance.TimeFreeze();
            Destroy(gameObject);


        }
    }

    
}
