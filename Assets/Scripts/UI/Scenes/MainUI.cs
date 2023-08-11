using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MainUI : UI_Scene
{
    

    enum Buttons
    {
        InfoButton,
        SettingButton,
        GotoGameButton,
        SkinTab,
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
    enum Images
    {
        Flower1,
        Flower2,
        Flower3,

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


        //BindEvent(GetButton((int)Buttons.GardenTab).gameObject, ToGarden);
        BindEvent(GetButton((int)Buttons.GotoGameButton).gameObject, ToGame);
        BindEvent(GetButton((int)Buttons.SkinTab).gameObject, ToFlowersBook);


        GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.Branch}";
        GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.GoldBranch}";
        GetText((int)Texts.MaxPoint).text = $"{GameManager.InGameDataManager.MaxPoint}";
        GetText((int)Texts.JumpCnt).text = $"{GameManager.InGameDataManager.QuestIDX}번 Quest에서 필요한 Jump 수: {GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Jump}";
        GetText((int)Texts.SkipCnt).text = $"{GameManager.InGameDataManager.QuestIDX}번 Quest에서 필요한 SKip 수: {GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Skip}";
        GetText((int)Texts.BloomCnt).text = $"{GameManager.InGameDataManager.QuestIDX}번 Quest에서 필요한 Bloom 수: {GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Bloom}";


        GetImage((int)Images.Flower1).sprite = GameManager.InGameDataManager.UseFlowerSprites[0];
        GetImage((int)Images.Flower2).sprite = GameManager.InGameDataManager.UseFlowerSprites[1];
        GetImage((int)Images.Flower3).sprite = GameManager.InGameDataManager.UseFlowerSprites[2];

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
