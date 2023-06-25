using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    #region Quest관련 Data
    public int QuestNum { get; set; }

    int _jumpCnt = 0;
    public int JumpCnt 
    {
        get { return _jumpCnt; }
        set { _jumpCnt = value; GameManager.UIManager.UIUpdate(QuestNum); }
    }
    int _skipCnt = 0;
    public int SkipCnt
    {
        get { return _skipCnt; }
        set { _skipCnt = value; GameManager.UIManager.UIUpdate(QuestNum); }
    }
    int _bloomCnt = 0;
    public int BloomCnt
    {
        get { return _bloomCnt; }
        set { _bloomCnt = value; GameManager.UIManager.UIUpdate(QuestNum); }
    }
    int _playRwrd = 0;
    public int PlayRwrd
    {

        get { _playRwrd = (SkipCnt * 1) + (JumpCnt * 2); return _playRwrd; }  //플레이 보상 계산 임시 수식 //아직 BloomCnt가 변수 선언되지 않아서 계산이 불가능해 수식에서 뺐습니다. 어차피 임시 수식이니까...
        set { _playRwrd = value; }

    }
    #endregion

    protected QuestHandler _questHandler = new QuestHandler();
    public QuestHandler QuestHandler { get { return _questHandler; } }       //자료구조


}
