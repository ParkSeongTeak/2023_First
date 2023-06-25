using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : State
{
    static NormalState _normalState;

    public static NormalState normalState { get { Init(); return _normalState; }  }
    NormalState() { }


    // Start is called before the first frame update
    static void Init()
    {
        if (_normalState == null )
        {
            _normalState = new NormalState();
            _normalState._questHandler = Util.ParseJson<QuestHandler>("NormalQuest", "_questHandler");
            _normalState.QuestNum = PlayerPrefs.GetInt("NormalQuestNum", 1);
        }

    }


}
