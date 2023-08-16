using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using static Define;
using static Unity.Burst.Intrinsics.X86.Avx;
using Unity.Mathematics;

public class MainUI : UI_Scene
{

    enum Buttons
    {
        InfoButton,
        OptionButton,
        GotoGameButton,
        SkinTab,
        Random,
    }

    enum Texts
    {
        QuestNum,
        JumpCnt,
        SkipCnt,
        BloomCnt,
        Branch,
        GoldBranch,
        MaxPoint,
        RandomRewardTxt,
    }
    enum Images
    {
        Flower1,
        Flower2,
        Flower3,
        RandomReward,
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
        BindEvent(GetButton((int)Buttons.OptionButton).gameObject, ShowOption);
        BindEvent(GetButton((int)Buttons.Random).gameObject, ShowRandomReward);


        GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.Branch}";
        GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.GoldBranch}";
        GetText((int)Texts.MaxPoint).text = $"{GameManager.InGameDataManager.MaxPoint}";

        //QuestNum
        GetText((int)Texts.QuestNum).text = $"Quest {GameManager.InGameDataManager.QuestIDX}";

        GetText((int)Texts.JumpCnt).text = $"{GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Jump}";
        GetText((int)Texts.SkipCnt).text = $"{GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Skip}";
        GetText((int)Texts.BloomCnt).text = $"{GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Bloom}";


        GetImage((int)Images.Flower1).sprite = GameManager.InGameDataManager.UseFlowerSprites[0];
        GetImage((int)Images.Flower2).sprite = GameManager.InGameDataManager.UseFlowerSprites[1];
        GetImage((int)Images.Flower3).sprite = GameManager.InGameDataManager.UseFlowerSprites[2];

        GameManager.InGameDataManager.UpdateBranchAndPointAction -= UpdateBranchAndPoint;
        GameManager.InGameDataManager.UpdateBranchAndPointAction += UpdateBranchAndPoint;

        ///Random보상
        System.Random random = new System.Random();
        if (GameManager.InGameDataManager.NeedToShowCutScene_prologue)
        {
            GameManager.InGameDataManager.SetRandomReward();
            GameManager.UIManager.ShowPopupUI<CutScene_Prologue>();
        }
        if (GameManager.InGameDataManager.NeedToShowCutScene_epilogue && GameManager.InGameDataManager.QuestIDX >= InGameDataManager.EPILOGUE)
        {
            GameManager.UIManager.ShowPopupUI<CutScene_Epilogue>();
        }
            
        GameManager.InGameDataManager.RandomRewardData = GameManager.InGameDataManager.GetRandomReward();

        GetImage((int)Images.RandomReward).gameObject.SetActive(false);
        


    }
   
    void UpdateBranchAndPoint()
    {
        GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.Branch}";
        GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.GoldBranch}";
        GetText((int)Texts.MaxPoint).text = $"{GameManager.InGameDataManager.MaxPoint}";

    }

    #region Button

    void ToGame(PointerEventData evt)
    {

        GameManager.SoundManager.Play(Define.SFX.Start_01);//Start_01효과음
        GameManager.SoundManager.StopBGM(Define.BGM.블라썸컴퍼니_01);//블라썸컴퍼니_01정지
        GameManager.SoundManager.Play(Define.BGM.블라썸_꽃도감);//블라썸_꽃도감
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);
       

    }
    void ToFlowersBook(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_01);//click_01효과음
        GameManager.SceneManager.LoadScene(Define.Scenes.FlowersBook);


    }

    void ShowRandomReward(PointerEventData evt)
    {
        if (!GetImage((int)Images.RandomReward).gameObject.activeSelf)
        {
            GameManager.SoundManager.Play(Define.SFX.congrats_01); //congrats_01효과음
            GetImage((int)Images.RandomReward).gameObject.SetActive(true);
            GetText((int)Texts.RandomRewardTxt).text = $"{Enum.GetName(typeof(RandomRewardData), GameManager.InGameDataManager.RandomRewardData)}";

        }
        else
        {
            GetImage((int)Images.RandomReward).gameObject.SetActive(false);

        }
    }

    void ShowOption(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.UIManager.ShowPopupUI<Option>();
    }


    #endregion
}
