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

    ClearRwrdHandler _clearRwrdHandler = new ClearRwrdHandler();
    public ClearRwrdHandler ClearRwrdHandler { get { return _clearRwrdHandler; } }

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

    int _playRwrd = 0;
    public int PlayRwrd
    {
       
        get { _playRwrd = (SkipCnt* 1) + (JumpCnt* 2); return _playRwrd;}  //플레이 보상 계산 임시 수식 //아직 BloomCnt가 변수 선언되지 않아서 계산이 불가능해 수식에서 뺐습니다. 어차피 임시 수식이니까...
        set { _playRwrd = value; }

    }

    // Start is called before the first frame update
    GameObject _player;
    public GameObject Player { get { return _player; } }
    GameObject _flower;
    public GameObject Flower { get { return _flower; } }
    public void init()
    {
        //시작시 Player가 존재함을 보장(Scene에 Player가 있다면 만들지 않는다.)
        _player = GameObject.Find("Player");
        if(_player == null)
        {
            _player = GameManager.ResourceManager.Instantiate("Player");
        }
        





        _flower = GameManager.ResourceManager.Instantiate("Flower");
        _scenarioHandler = Util.ParseJson<ScenarioHandler>();       //Json data를 자료구조로 가지고 오기
        _normalQuestHandler = Util.ParseJson<NormalQuestHandler>();
        _clearRwrdHandler = Util.ParseJson<ClearRwrdHandler>();

        Debug.Log(_normalQuestHandler[1].Quest +" "+ _normalQuestHandler[1].Jump + " " + _normalQuestHandler[1].Skip + " " + _normalQuestHandler[1].Bloom);           //

       // Debug.Log(_scenarioHandler[$"{1}_{0}"].Dialogue);           //

    }

    

    // Update is called once per frame
    public void Clear()
    {

    }
}
