using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutScene_Prologue : UI_PopUp
{

    enum Images
    {
        CutScene_prologue1_1,
        CutScene_prologue1_2,
        CutScene_prologue1_3,

        CutScene_prologue2_1,
        CutScene_prologue2_2,
        CutScene_prologue2_3,

        CutScene_prologue3_1,
        CutScene_prologue3_2,
        CutScene_prologue3_3,
        
        BG,
    }
    enum Buttons
    {
        CutScene_Prologue,
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

        for(int i=1;i< Enum.GetValues(typeof(Images)).Length; i++)
        {
            GetImage(i).gameObject.SetActive(false);
        }
        GetImage((int)Images.BG).gameObject.SetActive(true);

        BindEvent(GetButton((int)Buttons.CutScene_Prologue).gameObject, Btn_CutScene_Prologue);
        Coroutine = StartCoroutine(Btn_CutScene_Prologue_Auto());

        GameManager.SoundManager.AudioSources[(int)Define.Sounds.BGM].mute = true;

    }
    Images CutScene = (Images)1;
    void Btn_CutScene_Prologue(PointerEventData evt)
    {
        StopCoroutine(Coroutine);

        if (CutScene == Images.BG)
        {
            GameManager.InGameDataManager.NeedToShowCutScene_prologue = false;
            ClosePopupUI();
            GameManager.SoundManager.AudioSources[(int)Define.Sounds.BGM].mute = false;
            return;
        }

        GetImage((int)CutScene).gameObject.SetActive(true);
        if(CutScene == Images.CutScene_prologue2_1)
        {
            for(int i = 0; i < 3; i++)
            {
                GetImage(i)?.gameObject.SetActive(false);
            }
        }
        if (CutScene == Images.CutScene_prologue3_1)
        {
            for (int i = 0; i < 6; i++)
            {
                GetImage(i)?.gameObject.SetActive(false);
            }
        }

        CutScene++;
        Coroutine = StartCoroutine(Btn_CutScene_Prologue_Auto());

    }
    IEnumerator Btn_CutScene_Prologue_Auto()
    {
        bool end = false;
        while (!end)
        {
            yield return new WaitForSeconds(1.4f);
            if (CutScene == Images.BG)
            {
                GameManager.InGameDataManager.NeedToShowCutScene_prologue = false;
                end = true;
                GameManager.SoundManager.AudioSources[(int)Define.Sounds.BGM].mute = false;

                ClosePopupUI();
                
            }

            GetImage((int)CutScene).gameObject.SetActive(true);
            if (CutScene == Images.CutScene_prologue2_1)
            {
                for (int i = 0; i < 3; i++)
                {
                    GetImage(i)?.gameObject.SetActive(false);
                }
            }
            if (CutScene == Images.CutScene_prologue3_1)
            {
                for (int i = 0; i < 6; i++)
                {
                    GetImage(i)?.gameObject.SetActive(false);
                }
            }

            CutScene++;
        }

    }
}
