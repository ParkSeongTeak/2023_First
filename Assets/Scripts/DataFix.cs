using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data Fix", menuName = "Scriptable Object/Data Fix", order = int.MaxValue)]
public class DataFix : ScriptableObject
{
    
    [SerializeField]
    private float ���ϼӵ�_12;
    public float Gravity_���ϼӵ� { get { return ���ϼӵ�_12; } }
    
    [SerializeField]
    private float �����Ŀ�_16;
    public float JumpPower_�������� { get { return �����Ŀ�_16; } }
    
    [SerializeField]
    private float Ÿ��Y�����_��3;
    public float TileY_Ÿ��Y����� { get { return Ÿ��Y�����_��3; } }
    
    [SerializeField]
    private float �ð��پ��¼ӵ�_��1;
    public float TimeSliderDeltatime_�ð��پ��¼ӵ� { get { return �ð��پ��¼ӵ�_��1; } }

}
