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
    
    #endregion

    // Start is called before the first frame update
    public void init()
    {
        //그냥....시작했다는 의미로 한번 넣어본
        GameManager.ResourceManager.Instantiate("Player");
        _scenarioHandler = Util.ParseJson<ScenarioHandler>();       //Json data를 자료구조로 가지고 오기

        Debug.Log(_scenarioHandler[$"{1}_{0}"].Dialogue);           //

    }

    // Update is called once per frame
    public void Clear()
    {
        
    }
}
