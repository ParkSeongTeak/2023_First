using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tile_mulmangcho1_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "����� ������. Ȯ��?"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {
        return Define.FlowerTypes.tile_mulmangcho1_blm;
    }
}
