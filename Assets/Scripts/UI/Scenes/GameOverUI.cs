using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class GameOverUI : UI_PopUp
{

    enum Buttons
    {
        RetryBtn,
        MainBtn,
    }
    enum Texts
    {
        JumpScore,
        SkipScore,
        BloomScore,
    }
    enum Images
    {

    }


    void Start()
    {
        Init();
    }

    public override void Init()
    {

        base.Init();

        Bind<Button>(typeof(Buttons));

        Bind<TMP_Text>(typeof(Texts));

        Bind<Image>(typeof(Images));

        BindEvent(GetButton((int)Buttons.RetryBtn).gameObject, ToGame);
        BindEvent(GetButton((int)Buttons.MainBtn).gameObject, ToMain);

        GetText((int)Texts.JumpScore).text = $"{GameManager.InGameDataManager.NowState.JumpCnt}";
        GetText((int)Texts.SkipScore).text = $"{GameManager.InGameDataManager.NowState.SkipCnt}";
        GetText((int)Texts.BloomScore).text = $"{GameManager.InGameDataManager.NowState.BloomCnt}";
    }

    #region Button
    void ToGame(PointerEventData evt)
    {
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);

    }
    void ToMain(PointerEventData evt)
    {
        GameManager.SceneManager.LoadScene(Define.Scenes.Main);

    }
    #endregion
}