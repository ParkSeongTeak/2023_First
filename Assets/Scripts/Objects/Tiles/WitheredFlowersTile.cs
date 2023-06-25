using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitheredFlowersTile : Tile
{
    public Define.WitheredFlowersTileTypes MyWitheredType { get; set; }

    public override void Init()
    {
        MyWitheredType = TileController.Instance.SetWitheredFlowersType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.WitheredFlowersTileSprites[(int)MyWitheredType];

    }
    public override void JumpOnMe()
    {
        GameManager.InGameDataManager.NowState.JumpCnt--;
        Destroy(gameObject);
    }
    public override void SkipOnMe()
    {

    }
}
