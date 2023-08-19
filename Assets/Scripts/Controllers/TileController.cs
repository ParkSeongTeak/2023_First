using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    // 여기 있으면 안될듯?
    Sprite[] _flowerSprites;
    Sprite[] _leafSprites;
    Sprite[] _witheredFlowersTileSprites;
    Sprite[] _bonusSprites;
    Sprite[] _cosmosFlowerSprites;

    public Sprite[] FlowerSprites { get { return _flowerSprites; } }
    public Sprite[] LeafSprites { get { return _leafSprites; } }
    public Sprite[] WitheredFlowersTileSprites { get { return _witheredFlowersTileSprites; } }
    public Sprite[] BonusSprites { get { return _bonusSprites; } }
    public Sprite[] CosmosFlowerSprites { get { return _cosmosFlowerSprites; } }


    #endregion 받아온 이미지들

    #region Tile 위치정보 관련
    const int _tileNum = 15;
    Vector3[] _tilePosition = new Vector3[_tileNum];
    public Vector3[] TilePosition { get { return _tilePosition; } }

    
    Vector3 _referenceTile = new Vector3(-12f,-2.5f,0);
    float _referenceDist = 3f;
    #endregion

    #region 지금Generated Tile들

 
    List<Tile> _nowGeneratedTiles = new List<Tile>();
    public List<Tile> NowGeneratedTiles { get { return _nowGeneratedTiles; } }

    #endregion 지금Generated Tile들

    #region BackGround 통제
    public Action BackGroundMove { get; set; }
    public Vector3 DeltaMove { get; set; }
    
    public BackGround[] BackGrounds { get; set; } = new BackGround[3];
    public int BackGroundIDX { get; set; } = 2;

    #endregion

    #region TileSmoothMove
    //윙윙이 움직이는 속도
    public const float OVERTIME = PlayerController.SPEED;
    public static bool IsMoving { get; set; }

    #endregion


    static Dictionary<TileType, Stack<Tile>> _poolingStack = new Dictionary<TileType, Stack<Tile>>();
    public static Dictionary<TileType, Stack<Tile>> PoolingStack { get { return _poolingStack; }}
    
    /// TileType => TileType.Flower == > Stack<Tile>중 어떤 객체
    /// 자동차 키 => BMW 16가 서울 6743 ==> 자동차 => BMW 16가 서울 6743 

    /// <summary>
    /// 존재함을 보장함
    /// </summary>
    /// 

    public static void init()
    {
        
        if (_instance == null)
        {
            GameObject flowerControl = GameObject.Find("TileController");
            if (flowerControl == null)
            {
                flowerControl = new GameObject { name = "TileController" };
                flowerControl.AddComponent<TileController>();
            }
            _instance = flowerControl.GetComponent<TileController>();

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
                _instance._flowerSprites[i] = GameManager.ResourceManager.Load<Sprite>($"Sprites/Flowers/{flowersSpritesStr[i]}"); 
                if(_instance._flowerSprites[i] == null)
                {
                    Debug.Log($"_instance.{flowersSpritesStr[i]} NULL");
                }
            }
            string[] leavesSpritesStr = Enum.GetNames(typeof(Define.LeafTypes));
            _instance._leafSprites = new Sprite[(int)Define.LeafTypes.MaxCount];
            for (int i = 0; i < (int)Define.LeafTypes.MaxCount; i++)
            {
                _instance._leafSprites[i] = GameManager.ResourceManager.Load<Sprite>($"Sprites/Leaves/{leavesSpritesStr[i]}");
                if (_instance._leafSprites[i] == null)
                {
                    Debug.Log("_instance.Leaves[(int)i] NULL");
                }

            }
            string[] witheredFlowersTileTypesStr = Enum.GetNames(typeof(Define.WitheredFlowersTileTypes));
            _instance._witheredFlowersTileSprites = new Sprite[(int)Define.WitheredFlowersTileTypes.MaxCount];
            for (int i = 0; i < (int)Define.WitheredFlowersTileTypes.MaxCount; i++)
            {
                _instance._witheredFlowersTileSprites[i] = GameManager.ResourceManager.Load<Sprite>($"Sprites/WitheredFlowersTileTypes/{witheredFlowersTileTypesStr[i]}");
                if (_instance._witheredFlowersTileSprites[i] == null)
                {
                    Debug.Log("_instance.WitheredFlowersTileTypes[(int)i] NULL");
                }

            }

            string[] BonusTileTypesStr = Enum.GetNames(typeof(Define.BonusTileTypes));
            _instance._bonusSprites = new Sprite[(int)Define.BonusTileTypes.MaxCount];
            for (int i = 0; i < (int)Define.BonusTileTypes.MaxCount; i++)
            {
                _instance._bonusSprites[i] = GameManager.ResourceManager.Load<Sprite>($"Sprites/BonusTiles/{BonusTileTypesStr[i]}");
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

            if (_instance.NowGeneratedTiles[3].TileType == TileType.LeafTypes)
            {
                _instance.LeafToFlower(3);
            }

            #endregion

            #region TileSmoothMove
            _instance.DeltaMove = new Vector3(0.5f, 0, 0);
            IsMoving = false;
            #endregion
}
    }

    GameObject GeneratedTile(int tilePos = _tileNum-1)
    {
        //TileType generateType = (TileType)UnityEngine.Random.RandomRange(0, (int)TileType.MaxCount);
        TileType generateType;
        int Random = UnityEngine.Random.RandomRange(0,100);

        if(Random < 60)
        {
            generateType = TileType.FlowerTypes;
        }
        else if(Random < 77)
        {
            generateType = TileType.WitheredFlowersTileTypes;
        }
        else if (Random < 97)
        {
            generateType = TileType.LeafTypes;
        }
        else
        {
            generateType = TileType.BonusTileTypes;
        }


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
    public GameObject LeafToFlower(int tilePos = _tileNum - 1)
    {

        Debug.Log("LeafToFlower");
        Tile tile = _nowGeneratedTiles[tilePos];
        tile.gameObject.SetActive(false);
        PoolingStack[tile.TileType].Push(tile);


        TileType generateType = TileType.FlowerTypes; ;
        
        if (_poolingStack[generateType].Count != 0)
        {
            Tile generateTile = _poolingStack[generateType].Pop();

            GameObject gameObject = generateTile.gameObject;
            gameObject.SetActive(true);
            generateTile.Init();
            generateTile.TilePosititon = tilePos;
            gameObject.transform.position = _instance._tilePosition[tilePos];
            _nowGeneratedTiles[tilePos] = generateTile;
            
            return gameObject;
        }
        else
        {
            Tile generateTile;
            string generateTileStr = Enum.GetName(typeof(TileType), generateType);
            GameObject gameObject = Instantiate(Resources.Load<GameObject>($"Prefabs/{generateTileStr}/{generateTileStr}"), _instance._tilePosition[tilePos], Quaternion.identity);
            generateTile = gameObject.GetComponent<Tile>();
            generateTile.Init();
            generateTile.TilePosititon = tilePos;
            gameObject.transform.position = _instance._tilePosition[tilePos];
            _nowGeneratedTiles[tilePos] = generateTile;
            return gameObject;
        }


    }
    public Define.FlowerTypes SetFlowerType()
    {
        return GameManager.InGameDataManager.UseFlowerList[UnityEngine.Random.RandomRange(0, InGameDataManager.useFlowerNum)];
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
    public Define.BudFlower SetCosmosFlowerType()
    {
        int Random = UnityEngine.Random.RandomRange(0, 60);

        if (Random < 5)
        {
            return BudFlower.BudOne;
        }
        else if (Random < 14)
        {
            return BudFlower.BudTwo;

        }
        else if (Random < 29)
        {
            return BudFlower.BudThree;
        }
        else if (Random < 44)
        {
            return BudFlower.BudFour;
        }
        else if (Random < 53)
        {
            return BudFlower.BudFive;
        }
        else
        {
            return BudFlower.BudSix;
        }

    }

    public void MoveTiles()
    {
        IsMoving = true;
        StartCoroutine(WaitTime());
        for (int i = 1; i < _tileNum; i++)
        {
            if (_instance._nowGeneratedTiles[i] != null)
            {
                _instance._nowGeneratedTiles[i]?.MoveNext(i);
            }
            
        }
        //맨 앞 지워줌
        _instance.DestoryTile(_instance?._nowGeneratedTiles[0]);
        
        GeneratedTile();
        
        
    }

    public void TileBreak(Tile tile)
    {
        tile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        tile.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DestoryTile(Tile tile)
    {
        tile.gameObject.SetActive(false);
        tile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        tile.GetComponent<BoxCollider2D>().enabled = true;
        PoolingStack[tile.TileType].Push(tile);
        int idx = _instance._nowGeneratedTiles.IndexOf(tile);
        _instance._nowGeneratedTiles.RemoveAt(idx);
    }
    public IEnumerator SmoothMove(Transform transform, Vector3 start, Vector3 end, float overTime = OVERTIME)
    {
        float startTime = Time.time;
        float endTime = startTime + overTime;
        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / overTime;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        transform.position = end;

    }
    public IEnumerator WaitTime(float overTime = OVERTIME)
    {
        yield return new WaitForSeconds(overTime);
        IsMoving = false;
    }

}
