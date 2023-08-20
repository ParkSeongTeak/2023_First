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
        if (!GameManager.InGameDataManager.NowUnbeat)
        {
            if (GameManager.InGameDataManager.NowState.LifeCnt > 2)
            {
                GameManager.InGameDataManager.NowState.LifeCnt--;                       //格见 别烙
                GameManager.SoundManager.Play(Define.SFX.GlassBreak);

            }
            else if (GameManager.InGameDataManager.NowState.LifeCnt == 2)
            {
                //GameUI.Instance.LifeIcon.SetActive(false);  //格见 酒捞袍 家葛 : 酒捞能 秦力
                GameManager.InGameDataManager.NowState.LifeCnt = 1;                       //格见 别烙
                GameManager.SoundManager.Play(Define.SFX.GlassBreak);
                GameUI.Instance.PlusLifeItemIcon.SetActive(false);


            }
            else
            {

                TileController.Instance.TileBreak(this);
                GameManager.SoundManager.Play(Define.SFX.Falling_02);//Falling_02瓤苞澜
                GameManager.SoundManager.StopBGM(Define.BGM.喉扼芥哪欺聪_01);
            }
        }

        //Destroy(gameObject);
    }
    public override void SkipOnMe()
    {

    }
}
