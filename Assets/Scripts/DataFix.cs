using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data Fix", menuName = "Scriptable Object/Data Fix", order = int.MaxValue)]
public class DataFix : ScriptableObject
{
    
    [SerializeField]
    private float 낙하속도_12;
    public float Gravity_낙하속도 { get { return 낙하속도_12; } }
    
    [SerializeField]
    private float 점프파워_16;
    public float JumpPower_점프높이 { get { return 점프파워_16; } }
    
    [SerializeField]
    private float 타일Y축높이_마3;
    public float TileY_타일Y축높이 { get { return 타일Y축높이_마3; } }
    
    [SerializeField]
    private float 시간줄어드는속도_쩜1;
    public float TimeSliderDeltatime_시간줄어드는속도 { get { return 시간줄어드는속도_쩜1; } }

}
