using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookSelect : BookState
{
    public override void Btn_Button(PointerEventData evt)
    {
        FlowerBook Button_ = evt.selectedObject.GetComponent<FlowerButton>().GetFlowerUI();
        System.Type tmpClassType = Button_.GetType();

        GameManager.UIManager.ShowPopupUI<FlowerBook>(tmpClassType.Name);
    }
}
