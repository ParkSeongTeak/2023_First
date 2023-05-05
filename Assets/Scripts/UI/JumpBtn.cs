using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpBtn : EventTriggerEX
{
    private void Start()
    {
        init();
    }

    protected override void OnPointerClick(PointerEventData data)
    {

        Debug.Log("JumpBtn눌림");
        //이 부분을 작성 안해주심
        GameManager.InGameDataManager.JumpCnt++;
    }
}
