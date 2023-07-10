using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����.....«�� 
/// �߾� ������ �ʿ��ѵ� �ָ��� �ֵ� �� ����� ��Ƽ� ó������
/// </summary>
public class InGameDataManager
{
    #region JsonData
    ClearRwrdHandler _clearRwrdHandler = new ClearRwrdHandler();
    public ClearRwrdHandler ClearRwrdHandler { get { return _clearRwrdHandler; } }
    #endregion

    #region State

    State _state;
    public State NowState { get { return _state; } }

    public void SetNormalState()
    {
        GameManager.InGameDataManager._state = NormalState.normalState; 
    }

    public void SetHardState()
    {
        GameManager.InGameDataManager._state = HardState.hardState;
    }


    #endregion



    #region Tile���� Data
    /// <summary>
    /// ���� �����Ǿ��ִ� Ÿ�� ���� �Ƹ� 7�� ����
    /// </summary>
    List<Tile> _tiles = new List<Tile>();
    public List<Tile> TileList { get { return _tiles;  } }

    public const int useFlowerNum = 3;
    FlowerBudTile[] _useFlowerList = new FlowerBudTile[useFlowerNum];
    public FlowerBudTile[] UseFlowerList { get { return _useFlowerList;  } set { _useFlowerList = value; } }

    #endregion


    // Start is called before the first frame update
    GameObject _player;
    public GameObject Player { get { return _player; } }
    GameObject _flower;
    public GameObject Flower { get { return _flower; } }
    #region Initiate
    public void init()
    {
        //���۽� Player�� �������� ����(Scene�� Player�� �ִٸ� ������ �ʴ´�.)
        /*
        _player = GameObject.Find("Player");
        if(_player == null)
        {
            _player = GameManager.ResourceManager.Instantiate("Player");
        }
        SetNormalState();

        Debug.Log(_state.QuestHandler[1].Jump); 
        */


    }
    #endregion

    public void CreatePlayer()
    {
        _player = GameObject.Find("Player");
        if (_player == null)
        {
            _player = GameManager.ResourceManager.Instantiate("Player");
        }
        SetNormalState();

        Debug.Log(_state.QuestHandler[1].Jump);
    }

    // Update is called once per frame
    public void Clear()
    {

    }
}
