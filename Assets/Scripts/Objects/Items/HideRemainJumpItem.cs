using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRemainJumpItem : Item
{
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);

        if (collision.gameObject.tag == "WingWing")
        {
            GameUI.Instance.HideRemainJumpItem();
        }

    }
}
