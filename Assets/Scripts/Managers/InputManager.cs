using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    Action _inputAction = null;
    public Action InputAction { get { return _inputAction; } set { _inputAction = value; } }
    
    public void init()
    {

    }
    void Dead()
    {
        //Á×À¸¸é TODO;
    }

    public void OnUpdate()
    {
        InputAction?.Invoke();
    }

    public void Clear()
    {

    }
}
