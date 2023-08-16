using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class icon_magnolia3 : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "목련"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }
    public override Define.FlowerTypes GetFlowerType()
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        return Define.FlowerTypes.icon_magnolia3;
    }
}
