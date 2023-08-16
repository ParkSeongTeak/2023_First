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
            if (GameManager.InGameDataManager.NowState.LifeCnt == 2)
            {
                GameManager.UIManager.ShowSceneUI<GameUI>().LifeIcon.SetActive(false);  //목숨 아이템 소모 : 아이콘 해제
                GameManager.InGameDataManager.NowState.LifeCnt = 1;                       //목숨 깎임

                /// 라이프가 깎이는 소리가 나야 맞을까요?

                GameManager.SoundManager.Play(Define.SFX.GlassBreak); 

                GameUI.Instance.PlusLifeItemIcon.SetActive(false);

            }
            else
            {
                TileController.Instance.DestoryTile(this);
                GameManager.SoundManager.Play(Define.SFX.Falling_02);//Falling_02효과음
                GameManager.SoundManager.StopBGM(Define.BGM.블라썸컴퍼니_01);
                Debug.Log("멈춤");
            }
        }

        //Destroy(gameObject);
    }
    public override void SkipOnMe()
    {

    }
}
