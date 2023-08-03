using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTile : Tile
{
    public Define.BonusTileTypes MyBonusType { get; set; }

    public override void Init()
    {
        MyBonusType = TileController.Instance.SetBonusType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.BonusSprites[(int)MyBonusType];

    }
    public override void JumpOnMe()
    {
        GameUI.Instance.timeSlider.PlusTime(0.2f);
    }


    public override void SkipOnMe()
    {

    }

    private bool isJumping;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WingWing")
        {
            if (isJumping == true)
            {
                GameUI.Instance.PlusTime();
                
            }
        }
    }

}






            
     