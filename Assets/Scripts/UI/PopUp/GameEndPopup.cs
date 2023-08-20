using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class GameEndPopup : UI_PopUp
{

    enum Buttons
    {
        GameEnd,
        ESC,
    }


    // Start is called before the first frame update
    void Start()
    {
        base.Init();

        //Object πŸ¿ŒµÂ
        Bind<Button>(typeof(Buttons));
       
        BindEvent(GetButton((int)Buttons.GameEnd).gameObject, GameEnd);
        BindEvent(GetButton((int)Buttons.ESC).gameObject, ESC);


    }
    void GameEnd(PointerEventData evt)
    {
        Application.Quit();
    }
    void ESC(PointerEventData evt)
    {
        GameManager.UIManager.ClosePopupUI();
    }
}
