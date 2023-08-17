using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class tile_mulmangcho1_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "¹°¸ÁÃÊ"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }

    public override Sprite FlowerIcon { get { _flowerIcon = GameManager.ResourceManager.Load<Sprite>($"Sprites/Flower_Icon/tile_mulmangcho1_blm"); return _flowerIcon; } set => throw new System.NotImplementedException(); }

    public override Define.FlowerTypes GetFlowerType()
    {
        return Define.FlowerTypes.tile_mulmangcho1_blm;
    }
}
