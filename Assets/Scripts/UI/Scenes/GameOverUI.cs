using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverUI : UI_PopUp
{

    enum Buttons
    {
        RetryBtn,
        MainBtn,
        GameEndBtn,
    }
    enum Texts
    {
        JumpScore,
        SkipScore,
        BloomScore,
        RewardText,
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
        BindEvent(GetButton((int)Buttons.GameEndBtn).gameObject, GameEnd);


        GetText((int)Texts.JumpScore).text = $"{GameManager.InGameDataManager.NowState.JumpCnt}";
        GetText((int)Texts.SkipScore).text = $"{GameManager.InGameDataManager.NowState.SkipCnt}";
        GetText((int)Texts.BloomScore).text = $"{GameManager.InGameDataManager.NowState.BloomCnt}";
        Reward();

    }

    #region Button
    void ToGame(PointerEventData evt)
    {

        GameManager.InGameDataManager.NowState.LifeCnt = 1;
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.SoundManager.Play(Define.BGM.블라썸컴퍼니_01);//블라썸컴퍼니_01
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);

    }
    void ToMain(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        GameManager.SoundManager.Play(Define.BGM.블라썸컴퍼니_01);//블라썸컴퍼니_01
        GameManager.SceneManager.LoadScene(Define.Scenes.Main);

    }
    void GameEnd(PointerEventData evt)
    {
        GameManager.UIManager.ShowPopupUI<GameEndPopup>();
    }

    #endregion

    #region Reward

    void Reward()
    {
        int addGoldBranch = 0;
        int addBranch = 0;
        int rare = -1;
        string RandomReward = "";
        if (GameUI.Instance.Clear)//클리어 함
        {
            GameManager.SoundManager.Play(Define.SFX.congrats_01); //congrats_01효과음
            GameManager.InGameDataManager.GoldBranch += GameUI.Instance.ClearReward_GoldBranch;
            addGoldBranch += GameUI.Instance.ClearReward_GoldBranch;
            
            switch (GameManager.InGameDataManager.RandomRewardData)
            {
                case 0:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    rare = GameManager.InGameDataManager.RandomRewardData;
                    break;
                case 1:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    rare = GameManager.InGameDataManager.RandomRewardData;

                    break;
                case 2:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    rare = GameManager.InGameDataManager.RandomRewardData;

                    break;
                case 3:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    rare = GameManager.InGameDataManager.RandomRewardData;

                    break;
                case 4:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    rare = GameManager.InGameDataManager.RandomRewardData;

                    break;
                case 5:
                    GameManager.InGameDataManager.SetRareListTrue(GameManager.InGameDataManager.RandomRewardData);
                    rare = GameManager.InGameDataManager.RandomRewardData;

                    break;

                case 6:

                    GameManager.InGameDataManager.GoldBranch += 1;
                    addGoldBranch += 1;
                    RandomReward = $"황금가지 {1}";
                    break;
                case 7:
                    GameManager.InGameDataManager.GoldBranch += 2;
                    addGoldBranch += 2;
                    RandomReward = $"황금가지 {2}";
                    break;
                case 8:
                    GameManager.InGameDataManager.GoldBranch += 3;
                    addGoldBranch += 3;
                    RandomReward = $"황금가지 {3}";
                    break;


                case 9:
                    GameManager.InGameDataManager.Branch += 2;
                    addBranch += 2;
                    RandomReward = $"나뭇가지 {2}";
                    break;
                case 10:
                    GameManager.InGameDataManager.Branch += 4;
                    addBranch += 4;

                    RandomReward = $"나뭇가지 {4}";
                    break;
                case 11:
                    GameManager.InGameDataManager.Branch += 6;
                    addBranch += 6;

                    RandomReward = $"나뭇가지 {6}";
                    break;
                case 12:
                    GameManager.InGameDataManager.Branch += 8;
                    addBranch += 8;

                    RandomReward = $"나뭇가지 {8}";
                    break;
                default:
                    break;
            }
            // 일반 브렌치;
            GameManager.InGameDataManager.Branch += (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);
            int _branch = (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);
            //addBranch += (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);




            GameManager.InGameDataManager.saveData();
            GameManager.InGameDataManager.SetRandomReward();
            string rarename = rare == -1 ? RandomReward : Enum.GetName(typeof(Define.RandomRewardData), rare);
            //나뭇가지 : n   황금가지 : n   랜덤보상 RR
            GetText((int)Texts.RewardText).text = $"나뭇가지 {_branch}   황금가지 {addGoldBranch}   + {rarename}";
        }
        else //클리어 못함
        {
            int _branch = (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);

            GameManager.InGameDataManager.Branch += (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);
            addBranch += (int)(GameManager.InGameDataManager.NowState.BloomCnt * State.Reward_Bloom_Weight);

            GameManager.InGameDataManager.saveData();
            GameManager.InGameDataManager.SetRandomReward();
            //나뭇가지 : n   황금가지 : n   랜덤보상 RR
            GetText((int)Texts.RewardText).text = $"나뭇가지 {_branch}   황금가지 {addGoldBranch}";
        }
        

    }

    #endregion
}