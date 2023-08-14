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
        
       

        if (Button_.GetHave())
        {
            FlowersBookUI.EnqueueSelectQueue(Button_.GetFlowerType());

            //Color color = new Color(1, 1, 1, 0.5f);
            Color color = new Color(0.6f, 0.6f, 0.6f, 1f);

            evt.selectedObject.GetComponent<Image>().color = color;


        }
        else
        {
            ShopUI shopUI = GameManager.UIManager.ShowPopupUI<ShopUI>();
            shopUI.SetUI(Button_);

        }
    }
}
