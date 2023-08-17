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
    Coroutine Coroutine;
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
        GetImage((int)Images.BG).gameObject.SetActive(true);

        BindEvent(GetButton((int)Buttons.CutScene_Epilogue).gameObject, Btn_CutScene_Epilogue);

        Coroutine = StartCoroutine(Btn_CutScene_Epilogue_Auto());

        GameManager.SoundManager.AudioSources[(int)Define.Sounds.BGM].mute = true;

    }
    Images CutScene = (Images)1;
    void Btn_CutScene_Epilogue(PointerEventData evt)
    {
        StopCoroutine(Coroutine);

        if (CutScene == Images.BG)
        {
            GameManager.InGameDataManager.NeedToShowCutScene_epilogue = false;
            ClosePopupUI();
            GameManager.SoundManager.AudioSources[(int)Define.Sounds.BGM].mute = false;
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
        Coroutine = StartCoroutine(Btn_CutScene_Epilogue_Auto());

    }
    IEnumerator Btn_CutScene_Epilogue_Auto()
    {
        bool end = false;
        while (!end)
        {
            yield return new WaitForSeconds(1.4f);
            if (CutScene == Images.BG)
            {
                GameManager.InGameDataManager.NeedToShowCutScene_epilogue = false;
                end = true;
                GameManager.SoundManager.AudioSources[(int)Define.Sounds.BGM].mute = false;


                ClosePopupUI();
            }
            else
            {
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
        
    }
}
