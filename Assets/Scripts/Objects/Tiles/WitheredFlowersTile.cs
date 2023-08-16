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
                GameManager.UIManager.ShowSceneUI<GameUI>().LifeIcon.SetActive(false);  //��� ������ �Ҹ� : ������ ����
                GameManager.InGameDataManager.NowState.LifeCnt = 1;                       //��� ����

                /// �������� ���̴� �Ҹ��� ���� �������?

                GameManager.SoundManager.Play(Define.SFX.GlassBreak); 

                GameUI.Instance.PlusLifeItemIcon.SetActive(false);

            }
            else
            {
                TileController.Instance.DestoryTile(this);
                GameManager.SoundManager.Play(Define.SFX.Falling_02);//Falling_02ȿ����
                GameManager.SoundManager.StopBGM(Define.BGM.�������۴�_01);
                Debug.Log("����");
            }
        }

        //Destroy(gameObject);
    }
    public override void SkipOnMe()
    {

    }
}
