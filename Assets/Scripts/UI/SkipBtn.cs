using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkipBtn : EventTriggerEX
{
    // Start is called before the first frame update
    void Start()

    {
        init();
    }
    protected override void
        OnPointerClick(PointerEventData data)
    {
        Debug.Log("SkipBtn´­¸²");
        GameManager.InGameDataManager.Player.transform.position += new Vector3(1, 0, 0);

        GameManager.InGameDataManager.SkipCnt++;
    }
            
         

        



    // Update is called once per frame
    
        
    
}
