using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class MainUI : UI_Scene
{
    

    enum Buttons
    {
        ModeButton,
        InfoButton,
        SettingButton,
        GotoGameButton,
        GardenTab,
        SkinTab,
        SelectTileButton,
    }

    enum Texts
    {
        JumpCnt,
        SkipCnt,
        BloomCnt,
        Branch,
        GoldBranch,
        MaxPoint,
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


        BindEvent(GetButton((int)Buttons.GardenTab).gameObject, ToGarden);
        BindEvent(GetButton((int)Buttons.GotoGameButton).gameObject, ToGame);
        BindEvent(GetButton((int)Buttons.SkinTab).gameObject, ToFlowersBook);


        GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.Branch}";
        GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.GoldBranch}";
        GetText((int)Texts.MaxPoint).text = $"{GameManager.InGameDataManager.MaxPoint}";
        
        
        GameManager.InGameDataManager.UpdateBranchAndPointAction -= UpdateBranchAndPoint;
        GameManager.InGameDataManager.UpdateBranchAndPointAction += UpdateBranchAndPoint;

    }
    void UpdateBranchAndPoint() 
    {
        GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.Branch}";
        GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.GoldBranch}";
        GetText((int)Texts.MaxPoint).text = $"{GameManager.InGameDataManager.MaxPoint}";




    }

    #region Button
    void ToGarden(PointerEventData evt)
    {
        GameManager.SceneManager.LoadScene(Define.Scenes.Garden);

    }
    void ToGame(PointerEventData evt)
    {
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);

    }
    void ToFlowersBook(PointerEventData evt)
    {
        GameManager.SceneManager.LoadScene(Define.Scenes.FlowersBook);

    }
    #endregion
}
