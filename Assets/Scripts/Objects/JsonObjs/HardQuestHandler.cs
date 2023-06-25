using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardQuestHandler : Handler
{
    public List<HardQuestData> _hardQuestHandler = new List<HardQuestData>();
    Dictionary<int, HardQuestData> _hardQuestDic = new Dictionary<int, HardQuestData>();
    public HardQuestData this[int idx]
    {
        get => _hardQuestDic[idx];
    }

    public override void ConvertToDic()
    {
        int idx = 0;
        while (idx < _hardQuestHandler.Count)
        {
            if (_hardQuestHandler[idx].Quest != 0)
            {
                _hardQuestDic.Add(_hardQuestHandler[idx].Quest, _hardQuestHandler[idx]);
            }
            idx++;
        }

    }


}

[Serializable]
public class HardQuestData
{
    public int Quest;
    public int Jump;
    public int Skip;
    public int Bloom;
    public int ClearReward_GoldBranch;
}
