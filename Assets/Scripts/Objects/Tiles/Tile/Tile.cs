using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using static Define;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
        Init();
    }

    public virtual void Init()
    {

    }
    public virtual void JumpOnMe() 
    {
        
    }

    public virtual void SkipOnMe()
    {
        
    }
    public bool MoveNext(int i)
    {
        TilePosititon -= 1;

        if (TilePosititon < 0)
        {
            return false;
        }
        else
        {
            //transform.position = TileController.Instance.TilePosition[i - 1];
            StartCoroutine(TileController.Instance.SmoothMove(transform, transform.position, TileController.Instance.TilePosition[i - 1], TileController.OVERTIME));
            return true;
        }
    }
    
    
}
