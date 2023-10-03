using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class Tile : MonoBehaviour
{
    /// <summary>
    /// ���� �� 
    /// </summary>
    int _jumpcnt;

    public int JumpCnt { get { return _jumpcnt; } set { _jumpcnt = value; } }

    /// <summary>
    /// ���� Ÿ���ΰ�?
    /// </summary>
    [SerializeField]
    TileType _tileType;
    public TileType TileType { get { return _tileType; }}

    [SerializeField]
    int _tilePosititon;

    /// <summary>
    /// Ÿ�� ��ġ index (idx) �� ǥ�� 
    /// </summary>


    public int TilePosititon { get { return _tilePosititon;  } set { _tilePosititon = value; } }

    /// <summary>
    /// �̹��� �� ������?
    /// </summary>
    public Sprite TileSprite { get; set; }
    
    
    private void Start()
    {
        //Cnt = 3;
        Init();
    }

    public abstract void Init();

    public abstract void JumpOnMe();
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
            StartCoroutine(TileController.Instance.SmoothMove(transform, transform.position, TileController.Instance.TilePosition[i - 1], TileController.OVERTIME));
            return true;
        }
    }

    public virtual void AllBloom()
    {

    }
    
    public virtual void ChangeFlower(int leafposition)
    {
        //Destroy(gameObject);
    }
    
}
