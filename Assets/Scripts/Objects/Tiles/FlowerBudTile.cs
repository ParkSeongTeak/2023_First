using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class FlowerBudTile : Tile
{
    public Define.FlowerTypes MyFlowerType { get; set; }
    public override void Init()
    {
        MyFlowerType = TileController.Instance.SetFlowerType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
    
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
