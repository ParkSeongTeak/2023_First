using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Page3 : UI_PopUp
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

        for (int Button = 0; Button <= (int)Buttons.Button12; Button++)
        {
            BindEvent(GetButton(Button).gameObject, Btn_Button);

        }

        BindEvent(GetButton((int)Buttons.Left).gameObject, Btn_Left);

    }
    void Btn_Button(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState.Btn_Button(evt);
    }

    void Btn_Left(PointerEventData evt)
    {
        ClosePopupUI();

        GameManager.UIManager.ShowPopupUI<Page2>();
        
    }
}
