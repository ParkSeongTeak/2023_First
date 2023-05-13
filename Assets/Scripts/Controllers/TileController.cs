using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class TileController : MonoBehaviour
{
    static TileController _instance = new TileController();

    public static TileController Instance { get { init(); return _instance; } }

    static Dictionary<TileType, Stack<TileController>> _poolingStack = new Dictionary<TileType, Stack<TileController>>();

    public Dictionary<TileType, Stack<TileController>> PoolingStack { get { return _poolingStack; }}
    private static void init()
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

            _poolingStack[TileType.FlowerBudTile] = new Stack<TileController>();
            _poolingStack[TileType.LeafTile] = new Stack<TileController>();
            _poolingStack[TileType.BonusTile] = new Stack<TileController>();
            _poolingStack[TileType.WitheredFlowersTile] = new Stack<TileController>();
        }
    }


}
