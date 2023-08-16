using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class tile_cherryblossom3_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "Ã¼¸®ºí¶ó½æ3"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {
        
        return Define.FlowerTypes.tile_cherryblossom3_blm;
    }

}
