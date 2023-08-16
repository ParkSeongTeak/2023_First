using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile_cherryblossom1_blm : FlowerBook

{
    public override string KoreanFlowerName { get { _koreanFlowerName = "º¢²É"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }
    public override Define.FlowerTypes GetFlowerType()
    {
        return Define.FlowerTypes.tile_cherryblossom1_blm;
    }
}
