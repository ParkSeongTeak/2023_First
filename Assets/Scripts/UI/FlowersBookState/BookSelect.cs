using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class BookSelect : BookState
{

    public override void Btn_Button(PointerEventData evt)
    {
        FlowerBook Button_ = evt.selectedObject.GetComponent<FlowerButton>().GetFlowerUI();

        if (Button_.GetHave())
        {
            FlowersBookUI.EnqueueSelectQueue(Button_.GetFlowerType());

            Color color = new Color(1, 1, 1, 0.5f);
            //Color color = new Color(0.1f, 0.1f, 0.1f, 1f);

            Define.FlowerBookIMG tmp = (Define.FlowerBookIMG)Enum.Parse(typeof(FlowerTypes), Button_.GetType().Name);
            Debug.Log($" {(FlowerTypes)Enum.Parse(typeof(FlowerTypes), Button_.GetType().Name)} ");
            
            evt.selectedObject.GetComponent<Image>().sprite = GameManager.ResourceManager.Load<Sprite>($"Sprites/OutLine/{Enum.GetName(typeof(Define.FlowerBookIMG), tmp)}");
            

            //evt.selectedObject.GetComponent<Image>().color = color;


        }
        else
        {
            ShopUI shopUI = GameManager.UIManager.ShowPopupUI<ShopUI>();
            shopUI.SetUI(Button_);

        }
    }
}
