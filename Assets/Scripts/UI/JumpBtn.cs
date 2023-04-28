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
        Debug.Log("JumpBtn´­¸²");
    }
}
