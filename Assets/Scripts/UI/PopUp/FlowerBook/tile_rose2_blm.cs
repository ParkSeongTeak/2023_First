using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class tile_rose2_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "Àå¹Ì"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_rose2_blm;
    }
}
