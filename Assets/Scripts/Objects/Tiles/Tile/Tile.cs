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
        JumpCnt = GameManager.InGameDataManager.NormalQuestHandler[1].Jump;
        Init();
    }

    public virtual void Init()
    {

    }
    public virtual void JumpOnMe() 
    {
        JumpCnt--;
    }

    public virtual void SkipOnMe()
    {
        
    }

}
