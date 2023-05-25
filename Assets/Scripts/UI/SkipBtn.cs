using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SkipBtn : EventTriggerEX
{
    void Start()
    { 
        init();
    }

    protected override void OnPointerClick(PointerEventData data)
    {
        Debug.Log("SkipBtn����");
        //GameManager.InGameDataManager.Player.transform.position += new Vector3(1, 0, 0);

        GameManager.InGameDataManager.SkipCnt++;
        TileController.Instance.MoveTiles();
    }
   
}
