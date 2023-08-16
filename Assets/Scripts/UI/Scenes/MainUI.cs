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
        OptionButton,
        GotoGameButton,
        SkinTab,
        Rare,
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

    enum RareTileName
    {
        레어꽃이름은모름1,
        레어꽃이름은모2름,
        레어꽃이름은3모름,
        레어꽃이름4은모름,
        레어꽃5이름은모름,
        레6어꽃이름은모름,

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

        if (GameManager.InGameDataManager.NeedToShowCutScene_prologue)
        {
            GameManager.UIManager.ShowPopupUI<CutScene_Prologue>();
        }
        if (GameManager.InGameDataManager.NeedToShowCutScene_epilogue && GameManager.InGameDataManager.QuestIDX >= InGameDataManager.EPILOGUE)
        {
            GameManager.UIManager.ShowPopupUI<CutScene_Epilogue>();
        }

        ///Random보상
        System.Random random  = new System.Random();

        GetImage((int)Images.RandomReward).gameObject.SetActive(false);
        //있어
        int rarenum = random.Next(0, 100);
        if (rarenum < 50)
        {
            List<int> tmp = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                if (!GameManager.InGameDataManager.GetRareList(i))
                {
                    tmp.Add(i);
                }
            }
            GameManager.InGameDataManager.HasRareItem = random.Next(0, tmp.Count);

            BindEvent(GetButton((int)Buttons.Rare).gameObject, ShowRandomReward);
        }
        else if(rarenum < 100)
        {
            GetButton((int)Buttons.Rare).gameObject.SetActive(false);

        }



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
            GetImage((int)Images.RandomReward).gameObject.SetActive(true);
            GetText((int)Texts.RandomRewardTxt).text = $"{Enum.GetName(typeof(RareTileName), GameManager.InGameDataManager.HasRareItem)}";

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
