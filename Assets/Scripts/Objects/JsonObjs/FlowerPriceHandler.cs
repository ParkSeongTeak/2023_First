using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPriceHandler : Handler
{
    public List<FlowerPriceData> _flowerPriceHandler = new List<FlowerPriceData>();
    Dictionary<string, FlowerPriceData> _flowerPriceDic = new Dictionary<string, FlowerPriceData>();
    public FlowerPriceData this[string idx]
    {
        get => _flowerPriceDic[idx];
    }
    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _flowerPriceHandler.Count)
        {
            if (_flowerPriceHandler[idx].FlowerName != null)
            {
                _flowerPriceDic.Add(_flowerPriceHandler[idx].FlowerName, _flowerPriceHandler[idx]);
            }
            idx++;
        }

    }
}

[Serializable]
public class FlowerPriceData
{
    public string FlowerName;
    public int Branch;
    public int GoldBranch;

}
