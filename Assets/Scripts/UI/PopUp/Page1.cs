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
    }

    enum FlowerInfo
    {
        icon_magnolia1,


    }



    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object 바인드
        Bind<Button>(typeof(Buttons));
        //Btn에 이벤트 연결
        //for(int button = 0; button < Enum.GetValues(typeof(Buttons)).Length; button++)
        //{
        //    BindEvent(GetButton(button).gameObject, Btn_Button);
        //}
        BindEvent(GetButton((int)Buttons.Button1).gameObject, Btn_Button1);
        BindEvent(GetButton((int)Buttons.Button2).gameObject, Btn_Button2);
        BindEvent(GetButton((int)Buttons.Button3).gameObject, Btn_Button3);
        BindEvent(GetButton((int)Buttons.Button4).gameObject, Btn_Button4);
        BindEvent(GetButton((int)Buttons.Button5).gameObject, Btn_Button5);
        BindEvent(GetButton((int)Buttons.Button6).gameObject, Btn_Button6);

        BindEvent(GetButton((int)Buttons.Button7).gameObject, Btn_Button1);
        BindEvent(GetButton((int)Buttons.Button8).gameObject, Btn_Button2);
        BindEvent(GetButton((int)Buttons.Button9).gameObject, Btn_Button3);
        BindEvent(GetButton((int)Buttons.Button10).gameObject, Btn_Button4);
        BindEvent(GetButton((int)Buttons.Button11).gameObject, Btn_Button5);
        BindEvent(GetButton((int)Buttons.Button12).gameObject, Btn_Button6);

    }
    protected void Btn_Button1(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia1>();
    }
    protected void Btn_Button2(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia2>();
    }
    protected void Btn_Button3(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia3>();
    }
    protected void Btn_Button4(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<tile_canola1_blm>();
    }
    protected void Btn_Button5(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<tile_canola2_blm>();
    }
    protected void Btn_Button6(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<tile_canola3_blm>();
    }


    protected void Btn_Button7(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<tile_cherryblossom1_blm>();
    }
    protected void Btn_Button8(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia1>();
    }
    protected void Btn_Button9(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia1>();
    }
    protected void Btn_Button10(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia1>();
    }
    protected void Btn_Button11(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia1>();
    }
    protected void Btn_Button12(PointerEventData evt)
    {
        //string name = evt.pointerPress.name;
        GameManager.UIManager.ShowPopupUI<icon_magnolia1>();
    }
}
