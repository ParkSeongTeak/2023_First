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
        //내가 상속한 함수(base == Tile)의 JumpOnMe() 실행
        base.JumpOnMe();

    }
    public override void SkipOnMe()
    {
         
    }
    
}
