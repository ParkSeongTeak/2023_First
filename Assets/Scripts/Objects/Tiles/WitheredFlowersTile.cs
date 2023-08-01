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

        if (GameManager.InGameDataManager.NowState.LifeCnt != 1)
        {
            GameManager.UIManager.ShowSceneUI<GameUI>().LifeIcon.SetActive(false);  //格见 酒捞袍 家葛 : 酒捞能 秦力
            GameManager.InGameDataManager.NowState.LifeCnt--;                       //格见 别烙
        }
        else
        {
            Destroy(gameObject);
        }
        
        //Destroy(gameObject);
    }
    public override void SkipOnMe()
    {

    }
}
