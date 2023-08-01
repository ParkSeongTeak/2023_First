using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeFreezeItem : Item
{
    
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
           
            
            GameUI.Instance.TimeFreeze();
            Destroy(gameObject);


        }
    }

    
}
