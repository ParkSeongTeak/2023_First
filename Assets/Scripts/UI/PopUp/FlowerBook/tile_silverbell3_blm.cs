using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class tile_silverbell3_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "Àº¹æ¿ï²É"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_silverbell3_blm;
    }
}
