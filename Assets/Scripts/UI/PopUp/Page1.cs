using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class Page1 : UI_PopUp
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

        tile_cherryblossom1_blm,
        tile_cherryblossom2_blm,
        tile_cherryblossom3_blm,
        icon_magnolia1,
        icon_magnolia2,
        icon_magnolia3,
        tile_canola1_blm,
        tile_canola2_blm,
        tile_canola3_blm,
        tile_mulmangcho1_blm,
        tile_mulmangcho2_blm,
        tile_mulmangcho3_blm,
        Right,
    }

   

    void Awake()
    {
        Init();

    }

    public override void Init()
    {
        base.Init();

        //Object 바인드
        Bind<Button>(typeof(Buttons));

        PlayerPrefs.SetInt($"tile_cherryblossom1_blmHave", 1);
        PlayerPrefs.SetInt($"tile_cherryblossom2_blmHave", 1);
        PlayerPrefs.SetInt($"tile_cherryblossom3_blmHave", 1);



        for (int Button = 0; Button < 12; Button++)
        {
            BindEvent(GetButton(Button).gameObject, Btn_Button);
            //GetButton(Button).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }

        BindEvent(GetButton((int)Buttons.Right).gameObject, Btn_Right);

    }

    void Btn_Button(PointerEventData evt)
    {
        /// 
        GameManager.InGameDataManager.bookState.Btn_Button(evt);
    }
    
    void Btn_Right(PointerEventData evt)
    {

        ClosePopupUI();
        GameManager.SoundManager.Play(Define.SFX.Page_01);//Page_01효과음
        GameManager.UIManager.ShowPopupUI<Page2>();
    }
}
