using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalQuestHandler : Handler
{
    public List<NormalQuestData> _normalQuestHandler = new List<NormalQuestData>();
    Dictionary<int, NormalQuestData> _normalQuestDic = new Dictionary<int, NormalQuestData>();
    public NormalQuestData this[int idx]
    {
        get => _normalQuestDic[idx];
    }
    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _normalQuestHandler.Count)
        {
            if (_normalQuestHandler[idx].Quest != 0)
            {
                _normalQuestDic.Add(_normalQuestHandler[idx].Quest, _normalQuestHandler[idx]);
            }
            idx++;
        }

    }
}

[Serializable]
public class NormalQuestData
{
    public int Quest;
    public int Jump;
    public int Skip;
    public int Bloom;
}
