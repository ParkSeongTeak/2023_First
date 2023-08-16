using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class tile_canola1_blm : FlowerBook

{
    public override string KoreanFlowerName { get { _koreanFlowerName = "À¯Ã¤²É"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_canola1_blm;
    }
}
