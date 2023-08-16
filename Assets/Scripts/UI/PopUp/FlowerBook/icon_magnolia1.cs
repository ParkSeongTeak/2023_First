using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class icon_magnolia1 : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "¸ñ·Ã"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {
        return Define.FlowerTypes.icon_magnolia1;
    }

}
