using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardState : State
{
    static HardState _hardState;
    public static HardState hardState { get { Init(); return _hardState; } }
    HardState() { }
    

    // Start is called before the first frame update
    static void Init()
    {
        if (_hardState == null)
        {
            _hardState = new HardState();
            _hardState.QuestNum = PlayerPrefs.GetInt("HardQuestNum", 1);

        }

    }

}
