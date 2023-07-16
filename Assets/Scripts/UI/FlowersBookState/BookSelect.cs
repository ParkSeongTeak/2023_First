using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BookSelect : BookState
{

    public override void Btn_Button(PointerEventData evt)
    {
        FlowerBook Button_ = evt.selectedObject.GetComponent<FlowerButton>().GetFlowerUI();
        System.Type tmpClassType = Button_.GetType();

        Color color = new Color(1,1,1,0.5f);
        evt.selectedObject.GetComponent<Image>().color = color;

        //GameManager.UIManager.ShowPopupUI<FlowerBook>(tmpClassType.Name);
    }
}
