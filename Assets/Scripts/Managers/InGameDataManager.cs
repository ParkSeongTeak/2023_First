using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����.....«�� 
/// �߾� ������ �ʿ��ѵ� �ָ��� �ֵ� �� ����� ��Ƽ� ó������
/// </summary>
public class InGameDataManager
{
    #region JsonData
    ScenarioHandler _scenarioHandler = new ScenarioHandler();       //�ڷᱸ��
    public ScenarioHandler ScenarioHandler { get { return _scenarioHandler; } }       //�ڷᱸ��

    NormalQuestHandler _normalQuestHandler = new NormalQuestHandler();
    public NormalQuestHandler NormalQuestHandler { get { return _normalQuestHandler; } }       //�ڷᱸ��

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
       
        get { _playRwrd = (SkipCnt* 1) + (JumpCnt* 2); return _playRwrd;}  //�÷��� ���� ��� �ӽ� ���� //���� BloomCnt�� ���� ������� �ʾƼ� ����� �Ұ����� ���Ŀ��� �����ϴ�. ������ �ӽ� �����̴ϱ�...
        set { _playRwrd = value; }

    }

    // Start is called before the first frame update
    GameObject _player;
    public GameObject Player { get { return _player; } }
    GameObject _flower;
    public GameObject Flower { get { return _flower; } }
    public void init()
    {
        //���۽� Player�� �������� ����(Scene�� Player�� �ִٸ� ������ �ʴ´�.)
        _player = GameObject.Find("Player");
        if(_player == null)
        {
            _player = GameManager.ResourceManager.Instantiate("Player");
        }
        





        _flower = GameManager.ResourceManager.Instantiate("Flower");
        _scenarioHandler = Util.ParseJson<ScenarioHandler>();       //Json data�� �ڷᱸ���� ������ ����
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
