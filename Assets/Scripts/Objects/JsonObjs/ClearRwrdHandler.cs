using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearRwrdHandler : Handler
{
    public List<ClearRwrdData> _clearRwrdHandler = new List<ClearRwrdData>();
    Dictionary<int, ClearRwrdData> _clearRwrdDic = new Dictionary<int, ClearRwrdData>();
    public ClearRwrdData this[int idx]
    {
        get => _clearRwrdDic[idx];
    }
    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _clearRwrdHandler.Count)
        {
            if (_clearRwrdHandler[idx].Quest != 0)
            {
                _clearRwrdDic.Add(_clearRwrdHandler[idx].Quest, _clearRwrdHandler[idx]);
            }
            idx++;
        }

    }
}

[Serializable]
public class ClearRwrdData
{
    public int Quest;
    public int Jump;
    public int Skip;
    public int Bloom;
    public int ClearReward_GoldBranch;

}
