using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class Page1 : UI_PopUp
{

    

    enum Buttons 
    {
        Button1,
        Button2,
        Button3,
        Button4,
        Button5,
        Button6,
        Button7,    
        Button8,
        Button9,
        Button10,
        Button11,
        Button12,
        Right,
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
        
        for (int Button = 0; Button <= (int)Buttons.Button12; Button++)
        {
            BindEvent(GetButton(Button).gameObject, Btn_Button);

        }

        
        BindEvent(GetButton((int)Buttons.Right).gameObject, Btn_Right);

    }

    void Btn_Button(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState.Btn_Button(evt);
    }
    
    void Btn_Right(PointerEventData evt)
    {

        ClosePopupUI();
        GameManager.UIManager.ShowPopupUI<Page2>();
    }
}
