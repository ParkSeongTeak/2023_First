using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tile_napal2_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "하..모르겠다."; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_napal2_blm;
    }
}
