using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class icon_magnolia3 : FlowerBook
{

    public override Define.FlowerTypes GetFlowerType()
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02È¿°úÀ½
        return Define.FlowerTypes.icon_magnolia3;
    }
}
