using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int _jumpcnt;
    public Sprite TileSprite { get; set; }
    public int JumpCnt{ get {return _jumpcnt; } set { _jumpcnt = value; } }


    private void Start()
    {
        //Cnt = 3;
        JumpCnt = GameManager.InGameDataManager.NormalQuestHandler[1].Jump;              //나중에 타일 별 jump수로 바꿔야함
        Init();
    }

    public virtual void Init()
    {

    }
    public virtual void JumpOnMe() 
    {
        if (JumpCnt > 0)
        {
            JumpCnt--;
            if (JumpCnt == 0)
            {
                GameManager.InGameDataManager.BloomCnt++;
            }
        }
        else
        {
            Debug.Log($"만개!");
            Destroy(gameObject);
        }
    }

    public virtual void SkipOnMe()
    {
        
    }

}
