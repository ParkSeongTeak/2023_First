using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 소위.....짬통 
/// 중앙 통제는 필요한데 애매한 애들 다 여기로 모아서 처리하자
/// </summary>
public class InGameDataManager
{
    #region JsonData
    ScenarioHandler _scenarioHandler = new ScenarioHandler();       //자료구조
    public ScenarioHandler ScenarioHandler { get { return _scenarioHandler; } }       //자료구조

    NormalQuestHandler _normalQuestHandler = new NormalQuestHandler();
    public NormalQuestHandler NormalQuestHandler { get { return _normalQuestHandler; } }       //자료구조



    #endregion
    int _jumpCnt = 0;
    public int JumpCnt 
    { 
        get { return _jumpCnt; } 
        set { _jumpCnt = value; GameManager.UIManager.UIUpdate();}                                
    }
    int _skipCnt = 0;
    public int SkipCnt
    {
        get { return _skipCnt; }
        set { _skipCnt = value; GameManager.UIManager.UIUpdate(); }
    }
    // Start is called before the first frame update
    GameObject _player;
    public GameObject Player { get { return _player; } }
    public void init()
    {
        //그냥....시작했다는 의미로 한번 넣어본
        _player = GameManager.ResourceManager.Instantiate("Player");
        _scenarioHandler = Util.ParseJson<ScenarioHandler>();       //Json data를 자료구조로 가지고 오기
        _normalQuestHandler = Util.ParseJson<NormalQuestHandler>();

        
        Debug.Log(_normalQuestHandler[1].Quest +" "+ _normalQuestHandler[1].Jump + " " + _normalQuestHandler[1].Skip + " " + _normalQuestHandler[1].Bloom);           //

       // Debug.Log(_scenarioHandler[$"{1}_{0}"].Dialogue);           //

    }

    // Update is called once per frame
    public void Clear()
    {

    }
}
