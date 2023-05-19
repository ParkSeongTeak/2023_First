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
        //내가 상속한 함수(base == Tile)의 JumpOnMe() 실행
        base.JumpOnMe();

    }
    public override void SkipOnMe()
    {
         
    }
    
}
