using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Page2 : UI_PopUp
{

    enum Buttons
    {
        tile_napal1_blm,
        tile_napal2_blm,
        tile_napal3_blm,
        tile_rose1_blm,
        tile_rose2_blm,
        tile_rose3_blm,
        tile_silverbell1_blm,
        tile_silverbell2_blm,
        tile_silverbell3_blm,
        tile_sumflower1_blm,
        tile_sumflower2_blm,
        tile_sumflower3_blm,
        Right,
        Left,
    }



    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object πŸ¿ŒµÂ
        Bind<Button>(typeof(Buttons));
        for (int Button = 0; Button < 12; Button++)
        {
            BindEvent(GetButton(Button).gameObject, Btn_Button);

        }

        BindEvent(GetButton((int)Buttons.Right).gameObject, Btn_Right);
        BindEvent(GetButton((int)Buttons.Left).gameObject, Btn_Left);


    }

    void Btn_Button(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState.Btn_Button(evt);
    }

    void Btn_Right(PointerEventData evt)
    {

        ClosePopupUI();
        GameManager.UIManager.ShowPopupUI<Page3>();

    }
    void Btn_Left(PointerEventData evt)
    {

        ClosePopupUI();
        GameManager.UIManager.ShowPopupUI<Page1>();

    }
}
