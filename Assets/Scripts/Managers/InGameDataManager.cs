using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 소위.....짬통 
/// 중앙 통제는 필요한데 애매한 애들 다 여기로 모아서 처리하자
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



    #region Tile관련 Data
    /// <summary>
    /// 현재 생성되어있는 타일 관리 아마 7개 내외
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
        //시작시 Player가 존재함을 보장(Scene에 Player가 있다면 만들지 않는다.)
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
