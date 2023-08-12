using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Page3 : UI_PopUp
{
    enum Buttons
    {
        tile_tulip_1,
        tile_tulip_2,
        tile_tulip_3,
        tile_violet1_blm,
        tile_violet2,
        tile_violet3_blm,
        tile_rare1_blm,
        tile_rare2_blm,
        tile_rare3_blm,
        tile_rare4_blm,
        tile_rare5_blm,
        tile_rare6_blm,
        Left,
    }



    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object ���ε�
        Bind<Button>(typeof(Buttons));

        for (int Button = 0; Button < 12; Button++)
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
        GameManager.SoundManager.Play(Define.SFX.Page_01);//Page_01ȿ����
        GameManager.UIManager.ShowPopupUI<Page2>();
        
    }
}
