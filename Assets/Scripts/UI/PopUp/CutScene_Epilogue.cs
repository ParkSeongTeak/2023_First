using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutScene_Epilogue : UI_PopUp
{
    enum Images
    {
        
        CutScene_epilogue1_1,
        CutScene_epilogue1_2,
        CutScene_epilogue1_3,

        CutScene_epilogue2_1,
        CutScene_epilogue2_2,
        CutScene_epilogue2_3,

        BG,

    }
    enum Buttons
    {
        CutScene_Epilogue,
    }

    void Awake()
    {
        Init();

    }

    public override void Init()
    {
        base.Init();

        //Object πŸ¿ŒµÂ
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        for (int i = 1; i < Enum.GetValues(typeof(Images)).Length; i++)
        {
            GetImage(i).gameObject.SetActive(false);
        }

        BindEvent(GetButton((int)Buttons.CutScene_Epilogue).gameObject, Btn_CutScene_Prologue);


    }
    Images CutScene = (Images)1;
    void Btn_CutScene_Prologue(PointerEventData evt)
    {
        if (CutScene == Images.BG)
        {
            GameManager.InGameDataManager.NeedToShowCutScene_epilogue = false;
            ClosePopupUI();
            return;
        }

        GetImage((int)CutScene).gameObject.SetActive(true);
        if (CutScene == Images.CutScene_epilogue2_1)
        {
            for (int i = 0; i < 3; i++)
            {
                GetImage(i)?.gameObject.SetActive(false);
            }
        }
        
        CutScene++;
    }
}
