using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using static Define;

public class Tile : MonoBehaviour
{
    /// <summary>
    /// 점프 수 
    /// </summary>
    int _jumpcnt;

    public int JumpCnt { get { return _jumpcnt; } set { _jumpcnt = value; } }

    /// <summary>
    /// 무슨 타입인가?
    /// </summary>
    [SerializeField]
    TileType _tileType;
    public TileType TileType { get { return _tileType; }}

    [SerializeField]
    int _tilePosititon;

    /// <summary>
    /// 타일 위치 index (idx) 로 표현 
    /// </summary>


    public int TilePosititon { get { return _tilePosititon;  } set { _tilePosititon = value; } }

    /// <summary>
    /// 이미지 뭐 쓸꺼야?
    /// </summary>
    public Sprite TileSprite { get; set; }
    
    
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
    public bool MoveNext()
    {
        TilePosititon -= 1;

        if (TilePosititon < 0)
        {
            return false;
        }
        else
        {
            //transform.position = TileController.Instance.TilePosition[TilePosititon];
            return true;
        }
    }
}
