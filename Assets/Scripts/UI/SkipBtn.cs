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

        if (!TileController.IsMoving)
        {
            //Background move라는 Action(Delegate 즉 대행자의 일종)에 값이 있으면 실행 BackGround에서 대행자가 처리할 일을 더 해 준다.
            TileController.Instance.BackGroundMove?.Invoke();

            GameManager.InGameDataManager.SkipCnt++;
            TileController.Instance.MoveTiles();
        }
    }
   
}
