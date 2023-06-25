using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestHandler : Handler
{

    public List<QuestData> _questHandler = new List<QuestData>();
    Dictionary<int, QuestData> _questDic = new Dictionary<int, QuestData>();
    public QuestData this[int idx]
    {
        get => _questDic[idx];
    }
    public override void ConvertToDic()
    {

        int idx = 0;
        while (idx < _questHandler.Count)
        {
            if (_questHandler[idx].Quest != 0)
            {
                _questDic.Add(_questHandler[idx].Quest, _questHandler[idx]);
            }
            idx++;
        }

    }
}

[Serializable]
public class QuestData
{
    public int Quest;
    public int Jump;
    public int Skip;
    public int Bloom;
    public int ClearReward_goldenstem;
}
