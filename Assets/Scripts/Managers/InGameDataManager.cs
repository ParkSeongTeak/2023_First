using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����.....«�� 
/// �߾� ������ �ʿ��ѵ� �ָ��� �ֵ� �� ����� ��Ƽ� ó������
/// </summary>
public class InGameDataManager 
{
    // Start is called before the first frame update
    public void init()
    {
        //�׳�....�����ߴٴ� �ǹ̷� �ѹ� �־
        GameManager.ResourceManager.Instantiate("Player");
    }

    // Update is called once per frame
    public void Clear()
    {
        
    }
}
