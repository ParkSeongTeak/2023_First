using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class tile_rare5_blm : FlowerBook
{
    public override string KoreanFlowerName { get { _koreanFlowerName = "�ʵ��ٶ���"; return _koreanFlowerName; } set => throw new System.NotImplementedException(); }
    public override Sprite FlowerIcon { get { _flowerIcon = GameManager.ResourceManager.Load<Sprite>($"Sprites/Flower_Icon/tile_rare5_blm"); return _flowerIcon; } set => throw new System.NotImplementedException(); }
    public override Define.FlowerTypes GetFlowerType()
    {

        return Define.FlowerTypes.tile_rare5_blm;
    }
}
