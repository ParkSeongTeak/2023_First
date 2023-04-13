using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 소위.....짬통 
/// 중앙 통제는 필요한데 애매한 애들 다 여기로 모아서 처리하자
/// </summary>
public class InGameDataManager 
{
    // Start is called before the first frame update
    public void init()
    {
        //그냥....시작했다는 의미로 한번 넣어본
        GameManager.ResourceManager.Instantiate("Player");
    }

    // Update is called once per frame
    public void Clear()
    {
        
    }
}
