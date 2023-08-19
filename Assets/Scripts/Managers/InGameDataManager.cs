using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling.Memory.Experimental;
using static Define;

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

    public float BGMVolume { get { return PlayerPrefs.GetFloat("BGMVolume", 1f); } set { PlayerPrefs.SetFloat("BGMVolume", value >= 1 ? 1 : value); } }
    public float SFXVolume { get { return PlayerPrefs.GetFloat("SFXVolume", 1f); } set { PlayerPrefs.SetFloat("SFXVolume", value >= 1 ? 1 : value); } }



    #endregion

    #region Tile관련 Data
    /// <summary>
    /// 현재 생성되어있는 타일 관리 아마 7개 내외
    /// </summary>
    List<Tile> _tiles = new List<Tile>();
    public List<Tile> TileList { get { return _tiles; } }

    public const int useFlowerNum = 3;
    FlowerTypes[] _useFlowerList = new FlowerTypes[useFlowerNum];
    public FlowerTypes[] UseFlowerList { get { return _useFlowerList; } set { _useFlowerList = value; } }

    Sprite[] _useFlowerSprites = new Sprite[useFlowerNum];
    public Sprite[] UseFlowerSprites { get { return _useFlowerSprites; } }

    public bool GetRareList(int idx)
    {
        return PlayerPrefs.GetInt($"RareList{idx}", 0) == 1;
    }

    public void SetRareListTrue(int idx) 
    {
        //tile_rare1_blm,
        //return PlayerPrefs.GetInt($"{tmpClassType.Name}Have", 0) > 0;
        //{ tmpClassType.Name}
        //Have

        string Raretile = Enum.GetName(typeof(FlowerTypes), Define.FlowerTypes.tile_rare1_blm + idx);
        PlayerPrefs.SetInt($"{Raretile}Have", 1);
        PlayerPrefs.SetInt($"RareList{idx}", 1);

    }





    #endregion

    #region Item관련 Data
    /// <summary>
    /// 현재 무적인가?
    /// </summary>
    public bool NowUnbeat { get; set; } = false;
    public bool PlusLife { get; set; } = false;
    #endregion Item관련 Data

    #region CutScenes

    public bool NeedToShowCutScene_prologue 
    { 
        get { return PlayerPrefs.GetInt("NeedToShowCutScene_prologue", 0) == 0; }
        set 
        { 
            if(value)
                PlayerPrefs.SetInt("NeedToShowCutScene_prologue", 0);
            else
            {
                PlayerPrefs.SetInt("NeedToShowCutScene_prologue", 1);

            }
        }
    }
    public const int EPILOGUE = 3;
    public bool NeedToShowCutScene_epilogue
    {
        get { return PlayerPrefs.GetInt("NeedToShowCutScene_epilogue", 0) == 0; }
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt("NeedToShowCutScene_epilogue", 0);
            }
            else
            {
                PlayerPrefs.SetInt("NeedToShowCutScene_epilogue", 1);
            }
        }
    }

    #endregion CutScenes

    #region Branch ,Point, Reward 관련 Data

    int _branch;
    public int Branch { get { return _branch; } set { PlayerPrefs.SetInt("Branch", value); _branch = value; } }

    int _goldBranch;
    public int GoldBranch { get { return _goldBranch; } set { PlayerPrefs.SetInt("GoldBranch", value); _goldBranch = value; }}

    int _maxPoint;
    public int MaxPoint { get { return _maxPoint; } set { PlayerPrefs.SetInt("MaxPoint", value); _maxPoint = value; } }
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
            _useFlowerSprites[i] = GameManager.ResourceManager.Load<Sprite>($"Sprites/Flower_Icon/{flowersSpritesStr[i]}");
            if (_useFlowerSprites[i] == null)
            {
                Debug.Log("_instance._flowerSprites[(int)i] NULL");
            }
        }
    }

    public int RandomRewardData { get; set; } = -1;
    public int GetRandomReward()
    {
        RandomRewardData = PlayerPrefs.GetInt("RandomRewardDecision", 6);
        return PlayerPrefs.GetInt("RandomRewardDecision", 6);
    }
    public int SetRandomReward()
    {

        System.Random random = new System.Random();
        int rarenum = random.Next(0, 100);
        int setData = 0;
        if (rarenum < 1 )
        {
            setData = 0;
        }
        else if (rarenum < 2)
        {
            setData = 1;

        }
        else if (rarenum < 3)
        {
            setData = 2;

        }
        else if (rarenum < 4)
        {
            setData = 3;

        }
        else if (rarenum < 5)
        {
            setData = 4;

        }
        else if (rarenum < 6)
        {
            setData = 5;

        }
        else if (rarenum < 14)
        {
            setData = 6;

        }
        else if (rarenum < 18)
        {
            setData = 7;

        }
        else if (rarenum < 20)
        {
            setData = 8;

        }
        else if (rarenum < 60)
        {
            setData = 9;

        }
        else if (rarenum < 80)
        {
            setData = 10;

        }
        else if (rarenum < 93)
        {
            setData = 11;

        }
        else if (rarenum < 100)
        {
            setData = 12;
        }

        if(setData < 6)
        {
            if (GetRareList(setData))
            {
                setData = 0;
                while (setData < 6)
                {
                    if (GetRareList(setData))
                    {
                        setData++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        RandomRewardData = setData;
        PlayerPrefs.SetInt("RandomRewardDecision", setData);
        return setData;
        
    }


    #endregion

    #region FlowersBook 관련 Data

    public bool SelectMode { get; set; }
    public BookState bookState { get; set; }
    public BookSelect bookSelect { get; set; }
    public BookInfo bookInfo { get; set; }


    #endregion


    int _questIDX;
    public int QuestIDX { get { return _questIDX; }  set { PlayerPrefs.SetInt("QUESTINDEX", value); _questIDX = value; } }
    
    public int LastQueset { get; private set; }

    // Start is called before the first frame update
    public GameObject _player;
    public GameObject Player { get { return _player; } }

    GameObject _flower;
    public GameObject Flower { get { return _flower; } }
    #region Initiate
    public void init()
    {
        _questIDX = PlayerPrefs.GetInt("QUESTINDEX", 1);
        _branch = PlayerPrefs.GetInt("Branch", 0);
        _goldBranch = PlayerPrefs.GetInt("GoldBranch", 0);
        _maxPoint = PlayerPrefs.GetInt("MaxPoint", 0);

        _flowerPriceHandler = Util.ParseJson<FlowerPriceHandler>();
        _clearRwrdHandler = Util.ParseJson<ClearRwrdHandler>();
        LastQueset = _clearRwrdHandler._clearRwrdHandler.Count-1;
        SelectMode = false;

        UseFlowerList[0] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[0]", (int)FlowerTypes.tile_cherryblossom1_blm);
        UseFlowerList[1] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[1]", (int)FlowerTypes.tile_cherryblossom2_blm); 
        UseFlowerList[2] = (FlowerTypes)PlayerPrefs.GetInt("UseFlowerList[2]", (int)FlowerTypes.tile_cherryblossom3_blm);

        string[] flowersSpritesStr = new string[useFlowerNum];

        for(int i = 0; i< useFlowerNum; i++)
        {
            flowersSpritesStr[i] = Enum.GetName(typeof(FlowerTypes), UseFlowerList[i]);
        }
        for (int i = 0; i < useFlowerNum; i++)
        {
            _useFlowerSprites[i] = GameManager.ResourceManager.Load<Sprite>($"Sprites/Flower_Icon/{flowersSpritesStr[i]}");

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
        Time.timeScale = 1.0f;
        _player = GameObject.Find("Player");
        if (_player == null)
        {
            _player = GameManager.ResourceManager.Instantiate("Player");
        }
        SetNormalState();
    }

    // Update is called once per frame
    public void Clear()
    {

    }
}
