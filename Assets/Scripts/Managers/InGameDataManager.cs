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

    #endregion
    public int _jumpCnt = 0;
    public int JumpCnt 
    { 
        get { return _jumpCnt; } set { _jumpCnt = value; GameManager.UIManager.UIUpdate();}                                
    }

    // Start is called before the first frame update
    GameObject _player;
    public GameObject Player { get { return _player; } }
    public void init()
    {
        //�׳�....�����ߴٴ� �ǹ̷� �ѹ� �־
        _player = GameManager.ResourceManager.Instantiate("Player");
        _scenarioHandler = Util.ParseJson<ScenarioHandler>();       //Json data�� �ڷᱸ���� ������ ����

        Debug.Log(_scenarioHandler[$"{1}_{0}"].Dialogue);           //

    }

    // Update is called once per frame
    public void Clear()
    {

    }
}
