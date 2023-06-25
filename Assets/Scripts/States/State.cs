using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    #region Quest���� Data
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

        get { _playRwrd = (SkipCnt * 1) + (JumpCnt * 2); return _playRwrd; }  //�÷��� ���� ��� �ӽ� ���� //���� BloomCnt�� ���� ������� �ʾƼ� ����� �Ұ����� ���Ŀ��� �����ϴ�. ������ �ӽ� �����̴ϱ�...
        set { _playRwrd = value; }

    }
    #endregion

    protected QuestHandler _questHandler = new QuestHandler();
    public QuestHandler QuestHandler { get { return _questHandler; } }       //�ڷᱸ��


}
