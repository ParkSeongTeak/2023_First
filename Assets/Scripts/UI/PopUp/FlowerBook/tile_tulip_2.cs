using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class tile_tulip_2 : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "ƫ��"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_tulip_2;
    }
}
