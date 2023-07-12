using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

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
    FlowerTypes[] _useFlowerList = new FlowerTypes[useFlowerNum];
    public FlowerTypes[] UseFlowerList { get { return _useFlowerList;  } set { _useFlowerList = value; } }

    Sprite[] _useFlowerSprites = new Sprite[useFlowerNum];
    public Sprite[] UseFlowerSprites { get { return _useFlowerSprites; } }


    #endregion

    #region Branch and Point ���� Data

    public int Branch { get; set; }
    public int GoldBranch { get; set; }
    public int MaxPoint { get; set; }
    Action _updateBranchAndPoint = null; 

    public Action UpdateBranchAndPointAction { get { return _updateBranchAndPoint; } set { _updateBranchAndPoint = value; } }
    public void UpdateBranchAndPoint() { UpdateBranchAndPointAction?.Invoke(); }

    void saveData() 
    {
        PlayerPrefs.SetInt("Branch", Branch);
        PlayerPrefs.SetInt("GoldBranch", GoldBranch);
        PlayerPrefs.SetInt("MaxPoint", MaxPoint);
    }
    #endregion

    #region FlowersBook ���� Data

    public bool SelectMode { get; set; }


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
        SelectMode = false;

        UseFlowerList[0] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[0]", (int)FlowerTypes.������);
        UseFlowerList[1] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[1]", (int)FlowerTypes.����ȭ); 
        UseFlowerList[2] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[2]", (int)FlowerTypes.�ڽ���);

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
