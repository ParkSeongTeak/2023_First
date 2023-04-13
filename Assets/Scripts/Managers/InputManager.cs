using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    Action _inputAction = null;
    /// <summary>
    /// 모든 Input 중앙 통제 
    /// 사용법은 
    /// GameManager.InputManager.InputAction += 원하는함수;
    /// 함수에 ()치지 말 것! 아니 함수인데 ()가 없다고? 'Delegate' 라는 키워드로 공부 바람
    /// </summary>
    public Action InputAction { get { return _inputAction; } set { _inputAction = value; } }
    
    public void init()
    {
        
    }
    public void OnUpdate()
    {
        InputAction?.Invoke();
    }

    public void Clear()
    {

    }
}
