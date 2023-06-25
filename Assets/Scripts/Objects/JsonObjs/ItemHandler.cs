using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : Handler
{
    public List<ItemData> _ItemOneHandler = new List<ItemData>();
    Dictionary<string, ItemData> _ItemOneDic = new Dictionary<string, ItemData>();
    public ItemData this[string idx]
    {
        get => _ItemOneDic[idx];
    }

    public List<ItemData> _ItemTwoHandler = new List<ItemData>();
    Dictionary<int, ItemData> _ItemTwoDic = new Dictionary<int, ItemData>();
    public ItemData this[int idx]
    {
        get => _ItemTwoDic[idx];
    }

    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _ItemOneHandler.Count)
        {
            if (_ItemOneHandler[idx].Item_Ingame != null)
            {
                _ItemOneDic.Add(_ItemOneHandler[idx].Item_Ingame, _ItemOneHandler[idx]);
            }
            idx++;
        }

        idx = 0;
        while (idx < _ItemTwoHandler.Count)
        {
            if (_ItemTwoHandler[idx].OccuranceProbs != 0)
            {
                _ItemTwoDic.Add(_ItemTwoHandler[idx].OccuranceProbs, _ItemTwoHandler[idx]);
            }
            idx++;
        }

    }


}

[Serializable]
public class ItemData
{
    public string Item_Ingame;
    public int OccuranceProbs;

}
