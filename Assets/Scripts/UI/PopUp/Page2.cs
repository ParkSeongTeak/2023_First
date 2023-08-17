using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Page2 : UI_PopUp
{
    enum Images
    {
        picture1,
        picture2,
        picture3,
        picture4,
        picture5,
        picture6,
        picture7,
        picture8,
        picture9,
        picture10,
        picture11,
        picture12,

    }
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

        //Object 바인드
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
        GameManager.SoundManager.Play(Define.SFX.Page_01);//Page_01효과음
        GameManager.UIManager.ShowPopupUI<Page3>();

    }
    void Btn_Left(PointerEventData evt)
    {

        ClosePopupUI();
        GameManager.SoundManager.Play(Define.SFX.Page_01);//Page_01효과음
        GameManager.UIManager.ShowPopupUI<Page1>();

    }
}
