using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapEasyHandler : Handler
{
    public List<TileMapEasyData> _tileMapEasyOneHandler = new List<TileMapEasyData>();
    Dictionary<string, TileMapEasyData> _tileMapEasyOneDic = new Dictionary<string, TileMapEasyData>();
    public TileMapEasyData this[string idx]
    {
        get => _tileMapEasyOneDic[idx];
    }

    public List<TileMapEasyData> _tileMapEasyTwoHandler = new List<TileMapEasyData>();
    Dictionary<int, TileMapEasyData> _tileMapEasyTwoDic = new Dictionary<int, TileMapEasyData>();
    public TileMapEasyData this[int idx]
    {
        get => _tileMapEasyTwoDic[idx];
    }

    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _tileMapEasyOneHandler.Count)
        {
            if (_tileMapEasyOneHandler[idx].Tile_Map != null)
            {
                _tileMapEasyOneDic.Add(_tileMapEasyOneHandler[idx].Tile_Map, _tileMapEasyOneHandler[idx]);
            }
            idx++;
        }

        idx = 0;
        while (idx < _tileMapEasyTwoHandler.Count)
        {
            if (_tileMapEasyTwoHandler[idx].OccuranceProbs != 0)
            {
                _tileMapEasyTwoDic.Add(_tileMapEasyTwoHandler[idx].OccuranceProbs, _tileMapEasyTwoHandler[idx]);
            }
            idx++;
        }

    }


}

[Serializable]
public class TileMapEasyData
{
    public string Tile_Map;
    public int OccuranceProbs;
    
}
