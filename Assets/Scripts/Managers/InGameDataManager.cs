using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

/// <summary>
/// 소위.....짬통 
/// 중앙 통제는 필요한데 애매한 애들 다 여기로 모아서 처리하자
/// </summary>
public class InGameDataManager
{
    #region JsonData
    ClearRwrdHandler _clearRwrdHandler = new ClearRwrdHandler();
    public ClearRwrdHandler ClearRwrdHandler { get { return _clearRwrdHandler; } }

    FlowerPriceHandler _flowerPriceHandler = new FlowerPriceHandler();
    public FlowerPriceHandler FlowerPriceHandler { get { return _flowerPriceHandler; } }

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
    FlowerTypes[] _useFlowerList = new FlowerTypes[useFlowerNum];
    public FlowerTypes[] UseFlowerList { get { return _useFlowerList;  } set { _useFlowerList = value; } }

    Sprite[] _useFlowerSprites = new Sprite[useFlowerNum];
    public Sprite[] UseFlowerSprites { get { return _useFlowerSprites; } }


    #endregion

    #region Branch and Point 관련 Data

    public int Branch { get; set; }
    public int GoldBranch { get; set; }
    public int MaxPoint { get; set; }
    Action _updateBranchAndPoint = null; 

    public Action UpdateBranchAndPointAction { get { return _updateBranchAndPoint; } set { _updateBranchAndPoint = value; } }
    public void UpdateBranchAndPoint() { UpdateBranchAndPointAction?.Invoke(); }

    public void saveData() 
    {
        PlayerPrefs.SetInt("Branch", Branch);
        PlayerPrefs.SetInt("GoldBranch", GoldBranch);
        PlayerPrefs.SetInt("MaxPoint", MaxPoint);
        PlayerPrefs.SetInt("UseFlowerList[0]", (int)UseFlowerList[0]);
        PlayerPrefs.SetInt("UseFlowerList[1]", (int)UseFlowerList[1]);
        PlayerPrefs.SetInt("UseFlowerList[2]", (int)UseFlowerList[2]);

        string[] flowersSpritesStr = new string[useFlowerNum];

        for (int i = 0; i < useFlowerNum; i++)
        {
            flowersSpritesStr[i] = Enum.GetName(typeof(FlowerTypes), UseFlowerList[i]);
        }
        for (int i = 0; i < useFlowerNum; i++)
        {
            _useFlowerSprites[i] = Resources.Load<Sprite>($"Sprites/Flowers/{flowersSpritesStr[i]}");
            if (_useFlowerSprites[i] == null)
            {
                Debug.Log("_instance._flowerSprites[(int)i] NULL");
            }
        }
    }
    #endregion

    #region FlowersBook 관련 Data

    public bool SelectMode { get; set; }
    public BookState bookState { get; set; }
    public BookSelect bookSelect { get; set; }
    public BookInfo bookInfo { get; set; }


    #endregion


    // Start is called before the first frame update
    GameObject _player;
    public GameObject Player { get { return _player; } }
    GameObject _flower;
    public GameObject Flower { get { return _flower; } }
    #region Initiate
    public void init()
    {
        Branch = PlayerPrefs.GetInt("Branch", 500);
        GoldBranch = PlayerPrefs.GetInt("GoldBranch", 40);
        MaxPoint = PlayerPrefs.GetInt("MaxPoint", 460);
        _flowerPriceHandler = Util.ParseJson<FlowerPriceHandler>();
        SelectMode = false;

        UseFlowerList[0] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[0]", (int)FlowerTypes.icon_magnolia1);
        UseFlowerList[1] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[1]", (int)FlowerTypes.icon_magnolia2); 
        UseFlowerList[2] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[2]", (int)FlowerTypes.icon_magnolia3);

        string[] flowersSpritesStr = new string[useFlowerNum];

        for(int i = 0; i< useFlowerNum; i++)
        {
            flowersSpritesStr[i] = Enum.GetName(typeof(FlowerTypes), UseFlowerList[i]);
        }
        for (int i = 0; i < useFlowerNum; i++)
        {
            _useFlowerSprites[i] = Resources.Load<Sprite>($"Sprites/Flowers/{flowersSpritesStr[i]}");
            if (_useFlowerSprites[i] == null)
            {
                Debug.Log("_instance._flowerSprites[(int)i] NULL");
            }
        }
        bookInfo = new BookInfo();
        bookSelect = new BookSelect();
        bookState = bookInfo;
        UpdateBranchAndPointAction -= saveData;
        UpdateBranchAndPointAction += saveData;



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
