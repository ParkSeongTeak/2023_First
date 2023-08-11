using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipJumpSwapItem : Item
{  
    private void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.gameObject.tag == "WingWing" && !GameUI.Instance.isUnbeatable) 
        {
            GameUI.Instance.SkipJumpSwapItem();
        }
    }

}


