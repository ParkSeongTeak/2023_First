using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class FlowerBudTile : Tile
{
    int JumpLeft;
    public Define.FlowerTypes MyFlowerType { get; set; }
    public Define.CosmosFlower FlowerJumpType { get; set; }
    public override void Init()
    {

        MyFlowerType = TileController.Instance.SetFlowerType(); //나중에 3개 중 랜덤으로 갖고 오는 코드로 변경해야함

        FlowerJumpType = TileController.Instance.SetCosmosFlowerType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[(int)FlowerJumpType];
        JumpLeft = (int)FlowerJumpType;
    }
    public override void JumpOnMe()
    {
        //내가 상속한 함수(base == Tile)의 JumpOnMe() 실행
        //base.JumpOnMe();
        if (JumpLeft >= 0)
        {
            JumpLeft--;
            if (JumpLeft > -1)
            {
                transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[JumpLeft];
            }
            if (JumpLeft == -1)
            {
                transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[(int)MyFlowerType];
                GameManager.InGameDataManager.NowState.BloomCnt++;
            }
        }
        else
        {
            GameManager.GameOver(2f);
            Destroy(gameObject);
        }
    }


    public override void SkipOnMe()
    {
         
    }
}
