using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Option : UI_PopUp
{
    enum Buttons
    {
        ESC,
        CutSceneShow,
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
        BindEvent(GetButton((int)Buttons.ESC).gameObject, Btn_ESC);


    }
    void Btn_ESC(PointerEventData evt)
    {
        GameManager.UIManager.ClosePopupUI();
    }

}
