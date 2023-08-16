using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tile_cherryblossom2_blm : FlowerBook
{

    public override string KoreanFlowerName { get { _koreanFlowerName = "Ã¼¸®ºí¶ó½æ2"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {
        return Define.FlowerTypes.tile_cherryblossom2_blm;
    }
}
