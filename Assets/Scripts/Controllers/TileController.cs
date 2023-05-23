using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using static Define;

public class TileController : MonoBehaviour
{
    /// <summary>
    /// 유일한 Controller
    /// </summary>
    static TileController _instance = new TileController();
    public static TileController Instance { get { init(); return _instance; } }


    #region 받아온 이미지들

    Sprite[] _flowerSprites;
    Sprite[] _leafSprites;
    Sprite[] _witheredFlowersTileSprites;
    Sprite[] _bonusSprites;

    public Sprite[] FlowerSprites { get { return _flowerSprites; } }
    public Sprite[] LeafSprites { get { return _leafSprites; } }
    public Sprite[] WitheredFlowersTileSprites { get { return _witheredFlowersTileSprites; } }
    public Sprite[] BonusSprites { get { return _bonusSprites; } }

    #endregion 받아온 이미지들


    #region Tile 위치정보 관련
    const int _tileNum = 8;
    Vector3[] _tilePosition = new Vector3[_tileNum];
    public Vector3[] TilePosition { get { return _tilePosition; } }

    
    Vector3 _referenceTile = new Vector3(-12,-5,0);
    float _referenceDist = 3f;

    #endregion



    #region 지금Generated Tile들

    /// <summary>
    /// 희망은 LinkedList
    /// </summary>
    /// 
    [SerializeField]
    List<Tile> _nowGeneratedTiles = new List<Tile>();
    public List<Tile> NowGeneratedTiles { get { return _nowGeneratedTiles; } }

    #endregion 지금Generated Tile들



    static Dictionary<TileType, Stack<Tile>> _poolingStack = new Dictionary<TileType, Stack<Tile>>();
    public static Dictionary<TileType, Stack<Tile>> PoolingStack { get { return _poolingStack; }}

    /// TileType == TileType.Flower == > Stack<Tile>중 어떤 객체
    /// 자동차 키 == BMW 16가 서울 6743 ==> 자동차 == BMW 16가 서울 6743 

    /// <summary>
    /// 존재함을 보장함
    /// </summary>
    public static void init()
    {
        if (_instance == null)
        {
            GameObject fowerControl = GameObject.Find("TileController");
            if (fowerControl == null)
            {
                fowerControl = new GameObject { name = "TileController" };
                fowerControl.AddComponent<TileController>();
            }
            _instance = fowerControl.GetComponent<TileController>();

            #region PoolingGenerate

            for(int i = 0; i< (int)TileType.MaxCount; i++)
            {
                _poolingStack[(TileType)i] = new Stack<Tile>();
            }
            
            #endregion PoolingGenerate

            #region GetTileSprites
            string[] flowersSpritesStr = Enum.GetNames(typeof(Define.FlowerTypes));
            _instance._flowerSprites = new Sprite[(int)Define.FlowerTypes.MaxCount];
            for(int i = 0 ; i< (int)Define.FlowerTypes.MaxCount; i++)
            {
                _instance._flowerSprites[i] = Resources.Load<Sprite>($"Sprites/Flowers/{flowersSpritesStr[i]}"); 
                if(_instance._flowerSprites[i] == null)
                {
                    Debug.Log("_instance._flowerSprites[(int)i] NULL");
                }
                    
            }
            string[] leavesSpritesStr = Enum.GetNames(typeof(Define.LeafTypes));
            _instance._leafSprites = new Sprite[(int)Define.LeafTypes.MaxCount];
            for (int i = 0; i < (int)Define.LeafTypes.MaxCount; i++)
            {
                _instance._leafSprites[i] = Resources.Load<Sprite>($"Sprites/Leaves/{leavesSpritesStr[i]}");
                if (_instance._leafSprites[i] == null)
                {
                    Debug.Log("_instance.Leaves[(int)i] NULL");
                }

            }
            string[] witheredFlowersTileTypesStr = Enum.GetNames(typeof(Define.WitheredFlowersTileTypes));
            _instance._witheredFlowersTileSprites = new Sprite[(int)Define.WitheredFlowersTileTypes.MaxCount];
            for (int i = 0; i < (int)Define.WitheredFlowersTileTypes.MaxCount; i++)
            {
                _instance._witheredFlowersTileSprites[i] = Resources.Load<Sprite>($"Sprites/WitheredFlowersTileTypes/{witheredFlowersTileTypesStr[i]}");
                if (_instance._witheredFlowersTileSprites[i] == null)
                {
                    Debug.Log("_instance.WitheredFlowersTileTypes[(int)i] NULL");
                }

            }

            string[] BonusTileTypesStr = Enum.GetNames(typeof(Define.BonusTileTypes));
            _instance._bonusSprites = new Sprite[(int)Define.BonusTileTypes.MaxCount];
            for (int i = 0; i < (int)Define.BonusTileTypes.MaxCount; i++)
            {
                _instance._bonusSprites[i] = Resources.Load<Sprite>($"Sprites/BonusTiles/{BonusTileTypesStr[i]}");
                if (_instance._bonusSprites[i] == null)
                {
                    Debug.Log("_instance.BonusTileTypesStr[(int)i] NULL");
                }

            }
            #endregion GetTileSprites

            #region TileGenerateInit
            float X = _instance._referenceTile.x;
            Vector3 now = _instance._referenceTile;
            for (int i = 0; i < _tileNum; i++)
            {
                _instance._tilePosition[i] = now;
                now.x += _instance._referenceDist;
            }
            for (int i = 0; i < _tileNum; i++)
            {
                _instance.GeneratedTile(i);
            }

            #endregion
        }
    }

    GameObject GeneratedTile(int tilePos = 7)
    {
        TileType generateType = (TileType)UnityEngine.Random.RandomRange(0, (int)TileType.MaxCount);
        if (_poolingStack[generateType].Count != 0)
        {
            Tile generateTile = _poolingStack[generateType].Pop();

            GameObject gameObject = generateTile.gameObject;
            gameObject.SetActive(true);

            generateTile.Init();
            generateTile.TilePosititon = tilePos;
            _instance._nowGeneratedTiles.Add(generateTile);
            gameObject.transform.position = _instance._tilePosition[tilePos];
            return gameObject;
        }
        else
        {
            Tile generateTile;
            string generateTileStr = Enum.GetName(typeof(TileType), generateType);
            GameObject gameObject = Instantiate(Resources.Load<GameObject>($"Prefabs/{generateTileStr}/{generateTileStr}"), _instance._tilePosition[tilePos] ,Quaternion.identity);
            generateTile = gameObject.GetComponent<Tile>();
            generateTile.Init();
            generateTile.TilePosititon = tilePos;
            gameObject.transform.position = _instance._tilePosition[tilePos];
            _instance._nowGeneratedTiles.Add(generateTile);
            return gameObject;
        }


    }

    public Define.FlowerTypes SetFlowerType()
    {
        return (Define.FlowerTypes)UnityEngine.Random.RandomRange(0, (int)Define.FlowerTypes.MaxCount);
    }
    public Define.LeafTypes SetLeafType()
    {
        return (Define.LeafTypes)UnityEngine.Random.RandomRange(0, (int)Define.LeafTypes.MaxCount);
    }
    public Define.WitheredFlowersTileTypes SetWitheredFlowersType()
    {
        return (Define.WitheredFlowersTileTypes)UnityEngine.Random.RandomRange(0, (int)Define.WitheredFlowersTileTypes.MaxCount);
    }
    public Define.BonusTileTypes SetBonusType()
    {
        return (Define.BonusTileTypes)UnityEngine.Random.RandomRange(0, (int)Define.BonusTileTypes.MaxCount);
    }


    public void MoveTiles()
    {
        
        for(int i = 1; i < _tileNum; i++)
        {
            if(_instance._nowGeneratedTiles[i].MoveNext())
            {
                _instance._nowGeneratedTiles[i].transform.position = _instance._tilePosition[i-1];
            }
        }
        //맨 앞 지워줌
        _instance.DistoryTile(_instance._nowGeneratedTiles[0]);
        
        GeneratedTile();
        
       
    }
    
    
    public void DistoryTile(Tile tile)
    {
        tile.gameObject.SetActive(false);
        PoolingStack[tile.TileType].Push(tile);
        Debug.Log("여기 지금 접근을 못하고있니?");
        _instance._nowGeneratedTiles.RemoveAt(0);
    }
}
