using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class PlusLifeItem : Item
{

    public GameObject Icon;
    GameObject icon;
    static GameUI gameUI;

    public override void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "WingWing")
        {
            GameUI.Instance.PlusLifeItem();        
        }
        base.OnTriggerStay2D(collision);


    }

}