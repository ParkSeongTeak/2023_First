using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using static Define;
/*
public class ItemController : MonoBehaviour
{
    static ItemController _instance = new ItemController();
    public static ItemController Instance { get { init(); return _instance; } }

    Sprite[] _itmSprites;
    public Sprite[] ItemSprites { get { return _itemSprites; } }

    #region Tile 위치정보 관련
    const int _tileNum = 15;
    Vector3[] _tilePosition = new Vector3[_tileNum];
    public Vector3[] TilePosition { get { return _tilePosition; } }


    Vector3 _referenceTile = new Vector3(-12f, -3.5f, 0);
    float _referenceDist = 3f;
    #endregion
    List<Tile> _nowGeneratedTiles = new List<Tile>();
    public List<Tile> NowGeneratedTiles { get { return _nowGeneratedTiles; } }

    #region BackGround 통제
    public Action BackGroundMove { get; set; }
    public Vector3 DeltaMove { get; set; }
    #endregion

    #region TileSmoothMove

    public const float OVERTIME = 0.33f;
    public static bool IsMoving { get; set; }

    #endregion

    #region GetTileSprites
    string[] itemStr = Enum.GetNames(typeof(Define.Items));
    _instance._itemSprites = new Sprite[(int)Define.Items.MaxCount];
            for(int i = 0 ; i<(int)Define.Items.MaxCount; i++)
            {
                _instance._items[i] = Resources.Load<Sprite>($"Sprites/Items/{itemStr[i]}"); 
                if(_instance._itemSprites[i] == null)
                {
                    Debug.Log("_instance._itemSprites[(int)i] NULL");
                }
            }
    #endregion

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

    #region TileSmoothMove
    _instance.DeltaMove = new Vector3(0.5f, 0, 0);
    IsMoving = false;
#endregion

    GameObject GeneratedTile(int tilePos = _tileNum - 1)
    {
        Tile generateTile;
        GameObject gameObject = Instantiate(Resources.Load<GameObject>($"Prefabs/{Items}/{Items}"), _instance._tilePosition[tilePos], Quaternion.identity);
        generateTile = gameObject.GetComponent<Tile>();
        generateTile.Init();
        generateTile.TilePosititon = tilePos;
        gameObject.transform.position = _instance._tilePosition[tilePos];
        _instance._nowGeneratedTiles.Add(generateTile);
        return gameObject;
    }

    public Define.Items SetItem()
    {
        return (Define.Items)UnityEngine.Random.RandomRange(0, (int)Define.Items.MaxCount);
    }

    public void MoveTiles()
    {
        IsMoving = true;

        for (int i = 1; i < _tileNum; i++)
        {
            _instance._nowGeneratedTiles[i].MoveNext(i);

        }
        StartCoroutine(WaitTime());
        GeneratedTile();


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
*/
