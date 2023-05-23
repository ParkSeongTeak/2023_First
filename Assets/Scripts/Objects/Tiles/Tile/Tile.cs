using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using static Define;

public class Tile : MonoBehaviour
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
        JumpCnt = GameManager.InGameDataManager.NormalQuestHandler[1].Jump;              //���߿� Ÿ�� �� jump���� �ٲ����
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
            Debug.Log($"����!");
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
