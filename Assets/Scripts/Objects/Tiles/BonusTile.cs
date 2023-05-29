using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       
    }
    public override void SkipOnMe()
    {

    }
}
