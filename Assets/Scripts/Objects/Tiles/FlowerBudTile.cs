using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBudTile : Tile
{
    public override void Init()
    {
        transform.GetComponent<SpriteRenderer>().sprite = TileSprite;
    }
    public override void JumpOnMe()
    {
        //���� ����� �Լ�(base == Tile)�� JumpOnMe() ����
        base.JumpOnMe();

    }
    public override void SkipOnMe()
    {
         
    }
    
}
