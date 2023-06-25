using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapHardHandler : Handler
{
    public List<TileMapHardData> _tileMapHardOneHandler = new List<TileMapHardData>();
    Dictionary<string, TileMapHardData> _tileMapHardOneDic = new Dictionary<string, TileMapHardData>();
    public TileMapHardData this[string idx]
    {
        get => _tileMapHardOneDic[idx];
    }

    public List<TileMapHardData> _tileMapHardTwoHandler = new List<TileMapHardData>();
    Dictionary<int, TileMapHardData> _tileMapHardTwoDic = new Dictionary<int, TileMapHardData>();
    public TileMapHardData this[int idx]
    {
        get => _tileMapHardTwoDic[idx];
    }

    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _tileMapHardOneHandler.Count)
        {
            if (_tileMapHardOneHandler[idx].Tile_Map != null)
            {
                _tileMapHardOneDic.Add(_tileMapHardOneHandler[idx].Tile_Map, _tileMapHardOneHandler[idx]);
            }
            idx++;
        }

        idx = 0;
        while (idx < _tileMapHardTwoHandler.Count)
        {
            if (_tileMapHardTwoHandler[idx].OccuranceProbs != 0)
            {
                _tileMapHardTwoDic.Add(_tileMapHardTwoHandler[idx].OccuranceProbs, _tileMapHardTwoHandler[idx]);
            }
            idx++;
        }

    }


}

[Serializable]
public class TileMapHardData
{
    public string Tile_Map;
    public int OccuranceProbs;

}
