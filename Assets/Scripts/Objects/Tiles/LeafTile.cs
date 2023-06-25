using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTile : Tile
{
    public Define.LeafTypes MyLeafType { get; set; }

    public override void Init()
    {
        MyLeafType = TileController.Instance.SetLeafType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.LeafSprites[(int)MyLeafType];

    }
    public override void JumpOnMe()
    {
        GameManager.InGameDataManager.NowState.JumpCnt--;
    }
    public override void SkipOnMe()
    {

    }
}
