using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    Action _inputAction = null;
    /// <summary>
    /// ��� Input �߾� ���� 
    /// ������ 
    /// GameManager.InputManager.InputAction += ���ϴ��Լ�;
    /// �Լ��� ()ġ�� �� ��! �ƴ� �Լ��ε� ()�� ���ٰ�? 'Delegate' ��� Ű����� ���� �ٶ�
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
