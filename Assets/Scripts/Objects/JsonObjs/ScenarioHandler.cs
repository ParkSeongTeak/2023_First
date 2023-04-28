using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Json을 이용한 Data Parsing
/// https://products.aspose.app/cells/ko/conversion/excel-to-json
/// Excel To Json 변환
/// </summary>
[Serializable]



public class ScenarioHandler : Handler
{
    public List<ScenarioData> _scenarioHandler = new List<ScenarioData>();
    Dictionary<string, ScenarioData> _scenarioDic = new Dictionary<string, ScenarioData>();
    public ScenarioData this[string idx]
    {
        get => _scenarioDic[idx];
    }
    public override void ConvertToDic() {
        int idx = 0;
        while (idx < _scenarioHandler.Count)
        {
            if (_scenarioHandler[idx].Progress != null)
            {
                _scenarioDic.Add(_scenarioHandler[idx].Progress, _scenarioHandler[idx]);
            }
            idx++;
        }
    
    }
}

/// <summary>
/// Json의 Data 명과 !!!완벽하게 동일해야함!!!!!
/// </summary>
[Serializable]
public class ScenarioData
{
    public string Progress;
    public string Name;
    public string Dialogue;
    public string Picture;
    public string Background;
    public string Action;
}


