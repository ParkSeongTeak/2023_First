using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class tile_sumflower2_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "해바라기"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_sumflower2_blm;
    }
}
