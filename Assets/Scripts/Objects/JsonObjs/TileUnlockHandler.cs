using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUnlockHandler : Handler
{
    public List<TileUnlockData> _tileUnlockOneHandler = new List<TileUnlockData>();
    Dictionary<string, TileUnlockData> _tileUnlockOneDic = new Dictionary<string, TileUnlockData>();
    public TileUnlockData this[string idx]
    {
        get => _tileUnlockOneDic[idx];
    }

    public List<TileUnlockData> _tileUnlockTwoHandler = new List<TileUnlockData>();
    Dictionary<int, TileUnlockData> _tileUnlockTwoDic = new Dictionary<int, TileUnlockData>();
    public TileUnlockData this[int idx]
    {
        get => _tileUnlockTwoDic[idx];
    }

    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _tileUnlockOneHandler.Count)
        {
            if (_tileUnlockOneHandler[idx].Tile_unlock != null)
            {
                _tileUnlockOneDic.Add(_tileUnlockOneHandler[idx].Tile_unlock, _tileUnlockOneHandler[idx]);
            }
            idx++;
        }

        idx = 0;
        while (idx < _tileUnlockTwoHandler.Count)
        {
            if (_tileUnlockTwoHandler[idx].Branch_unlock != 0)
            {
                _tileUnlockTwoDic.Add(_tileUnlockTwoHandler[idx].Branch_unlock, _tileUnlockTwoHandler[idx]);
            }
            idx++;
        }

    }

   
}

[Serializable]
public class TileUnlockData
{
    public string Tile_unlock;
    public int Branch_unlock;
    public int GoldBranch_unlock;

}
