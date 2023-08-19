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
        RandomRewardBtn,
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
        BindEvent(GetButton((int)Buttons.RandomRewardBtn).gameObject, RandomRewardBtn);


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

        ///Random����
        System.Random random = new System.Random();
        if (GameManager.InGameDataManager.NeedToShowCutScene_prologue)
        {
            GameManager.InGameDataManager.SetRandomReward();
            GameManager.UIManager.ShowPopupUI<CutScene_Prologue>();
            GameManager.SoundManager.Play(Define.SFX.Mumble_01);//Mumble_01 ȿ����
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

        GameManager.SoundManager.Play(Define.SFX.Start_01);//Start_01ȿ����
        GameManager.SoundManager.StopBGM(Define.BGM.��������۴�_01);//��������۴�_01����
        GameManager.SoundManager.Play(Define.BGM.�����_�ɵ���);//�����_�ɵ���
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);
       

    }
    void ToFlowersBook(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_01);//click_01ȿ����
        GameManager.SoundManager.StopBGM(Define.BGM.��������۴�_01);//��������۴�_01����
        GameManager.SoundManager.Play(Define.BGM.�����_�ɵ���);//�����_�ɵ���
       // GameManager.SoundManager.BGM.(�����_�ɵ���).volume = 0.5f; // 0���� 1 ������ ������ ����

        
        GameManager.SceneManager.LoadScene(Define.Scenes.FlowersBook);


    }

    void ShowRandomReward(PointerEventData evt)
    {
        if (!GetImage((int)Images.RandomReward).gameObject.activeSelf)
        {
            GameManager.SoundManager.Play(Define.SFX.click_02); //click_02ȿ����
            GetImage((int)Images.RandomReward).gameObject.SetActive(true);
            GetText((int)Texts.RandomRewardTxt).text = $"Ȯ�κ�(Ȯ�� ���ص� ȹ�氡��) brance - 5 ";



        }
        else
        {
            GetImage((int)Images.RandomReward).gameObject.SetActive(false);

        }
    }

    void ShowOption(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02ȿ����
        GameManager.UIManager.ShowPopupUI<Option>();
    }

    void RandomRewardBtn(PointerEventData evt)
    {
        if (GameManager.InGameDataManager.Branch > 5)
        {
            GameManager.InGameDataManager.Branch -= 5;
            GetText((int)Texts.RandomRewardTxt).text = $"{Enum.GetName(typeof(RandomRewardData), GameManager.InGameDataManager.RandomRewardData)}";
            GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.Branch}";
            GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.GoldBranch}";
            GetText((int)Texts.MaxPoint).text = $"{GameManager.InGameDataManager.MaxPoint}";
            GetButton((int)Buttons.RandomRewardBtn).gameObject.SetActive(false);
        }
        
    }
    #endregion
}
