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

        //게임 정지         // 이는 Scene을 이동한다고 풀리지 않음 InGameDataManager.CreatePlayer()에서 다시 TimeScale을 조정해줌
        Time.timeScale = 0f;

        Bind<Button>(typeof(Buttons));

        Bind<TMP_Text>(typeof(Texts));

        Bind<Image>(typeof(Images));

        BindEvent(GetButton((int)Buttons.RetryBtn).gameObject, ToGame);
        BindEvent(GetButton((int)Buttons.MainBtn).gameObject, ToMain);
        

        GetText((int)Texts.JumpScore).text = $"{GameManager.InGameDataManager.NowState.JumpCnt}";
        GetText((int)Texts.SkipScore).text = $"{GameManager.InGameDataManager.NowState.SkipCnt}";
        GetText((int)Texts.BloomScore).text = $"{GameManager.InGameDataManager.NowState.BloomCnt}";
        Reward();

    }

    #region Button
    void ToGame(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);

    }
    void ToMain(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.SceneManager.LoadScene(Define.Scenes.Main);

    }
    #endregion

    #region Reward

    void Reward()
    {
        if (GameUI.Instance.Clear)
        {
            GameManager.InGameDataManager.GoldBranch += GameUI.Instance.ClearReward_GoldBranch;
            switch (GameManager.InGameDataManager.RandomRewardData)
            {
                case 0:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    break;
                case 1:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    break;
                case 2:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);

                    break;
                case 3:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);

                    break;
                case 4:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);

                    break;
                case 5:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    
                    break;

                case 6:

                    GameManager.InGameDataManager.GoldBranch += 1;
                    break;
                case 7:
                    GameManager.InGameDataManager.GoldBranch += 2;

                    break;
                case 8:
                    GameManager.InGameDataManager.GoldBranch += 3;

                    break;


                case 9:
                    GameManager.InGameDataManager.Branch += 2;

                    break;
                case 10:
                    GameManager.InGameDataManager.Branch += 4;

                    break;
                case 11:
                    GameManager.InGameDataManager.Branch += 6;

                    break;
                case 12:
                    GameManager.InGameDataManager.Branch += 8;

                    break;
                default:
                    break;
            }

        }

        // 일반 브렌치;
        GameManager.InGameDataManager.Branch += (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);
        GameManager.InGameDataManager.saveData();
        GameManager.InGameDataManager.SetRandomReward();
    }

    #endregion
}