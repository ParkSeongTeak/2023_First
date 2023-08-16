using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookInfo : BookState
{
    public override void Btn_Button(PointerEventData evt)
    {

        FlowerBook Button_ = evt.selectedObject.GetComponent<FlowerButton>().GetFlowerUI();
        if (Button_.GetHave())
        {
            System.Type tmpClassType = Button_.GetType();

            GameManager.UIManager.ShowPopupUI<FlowerBook>(tmpClassType.Name);
        }
        else
        {
            
            ShopUI shopUI = GameManager.UIManager.ShowPopupUI<ShopUI>();
            shopUI.SetUI(Button_);
        
        
        }

    }
}
