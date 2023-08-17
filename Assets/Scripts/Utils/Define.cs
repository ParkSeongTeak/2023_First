using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이곳은 사용할 Enum만을 관리하는 영역입니다.
/// 반드시! 모든 Enum 끝에는 MaxCount 로 끝내야합니다.
/// </summary>
public class Define 
{
    public enum Scenes
    {
        Start,
        Main,
        Game,
        Garden,
        FlowersBook,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    /// <summary>
    /// State 
    /// </summary>
    public enum States
    {

        Lose,
        Play,
        Pause,
        Win,
        MaxCount
    }
    /// <summary>
    /// 사용할 모든 Button의 "이름"을 이곳에 넣을것 
    /// ***절대*** 이곳에 버튼의 이름과 밖의 버튼 이름이 다르면 안됨
    /// 버튼의 이름을 바꾸면 반드시!!!!!! 이곳에서도 이름을 동일하게 유지해줘야해
    /// </summary>
    public enum Buttons
    {

        JumpBtn,
        SkipBtn,
        MaxCount
    }
    /// <summary>
    /// 사용할 모든 Text의 "이름"을 이곳에 넣을것 
    /// ***절대*** 이곳에 Text의 이름과 밖의 버튼 이름이 다르면 안됨
    /// Text의 이름을 바꾸면 반드시!!!!!! 이곳에서도 이름을 동일하게 유지해줘야해
    /// </summary>
    public enum Texts
    {
        ScoreTxt,
        JumpCnt,
        SkipCnt,
        BloomCnt,
        GoldenBranch,
        LifeCnt,
        Branch,
        RareTile,
        JumpScore,
        SkipScore,
        BloomScore,
        MaxCount
    }

    /// <summary>
    /// Images는 컨트롤 해줘야 하는 애들만 알아서 적당히 관리합시다. 
    /// 너무나 당연하지만 컨트롤 해줘야 하는 이미지의 이름은 같아야합니다.
    /// </summary>
    public enum Images
    {
        flowerImg,
        MaxCount
    }



    /// <summary>
    /// 건들지 말것
    /// </summary>
    public enum Sounds
    {
        BGM,
        SFX,
        MaxCount
    }


    //////////////////////////////////////////////////////////////////////
    /// <summary>
    /// BGM 음악들을 넣어주는 공간
    /// ***반드시****
    /// 노래가 
    /// Assets/Resources/Sounds에 있는지 확인하고 추가하자
    /// </summary>
    
    public enum BGM //loop O
    {
        블라썸_꽃도감,
        블라썸컴퍼니_01,
        MaxCount
    }

    /// <summary>
    /// SFX(효과음) 음악들을 넣어주는 공간
    /// ***반드시****
    /// 노래가 
    /// Assets/Resources/Sounds에 있는지 확인하고 추가하자
    /// </summary>
    public enum SFX // loop X
    {
        Skip_01,//게임UI 스크립트
        Jump_01,//게임UI 스크립트
        Bee_01,//보류
        Bloom_01,//완
        click_01,//완
        Start_01,//MainUI에서 사용
        click_02,//
        congrats_01,//MainUI에서 사용
        /*congrats02_01,
        congrats02_02,*///보류> 사용 예정X
        congrats02_03,//Shop UI에서사용 완
        Error_01,//Shop UI에서사용 완
        Falling_01,//보류
        Falling_02,//WitheredFlowerTile에서 사용
        GameOver_01,//타임슬라이드 스크립트에서 사용 
        GlassBreak,//플러스라이프아이템 스크립트에서 사용
        //Mumble_01,하드모드 없으므로 사용X
        Page_01,//Pag_01,02,03에서 사용

        MaxCount
    }

    //////////////////////////////////////////////////////////////////////

    public enum PopUpUI
    {
        GameOverMenu,
        MaxCount
    }
    
    /// <summary>
    /// 꽃봉오리 타일 :   FlowerBudTile
    /// 잎 타일 :         LeafTile 
    /// 시든 꽃 타일 :    WitheredFlowersTile
    /// 보너스 타일 :     BonusTile
    /// </summary>
    public enum TileType
    {
        FlowerTypes,
        LeafTypes,
        WitheredFlowersTileTypes,
        BonusTileTypes,
        MaxCount

    }
    public enum FlowerTypes  //blm 파일들만 넣어놓기
    {
        tile_cherryblossom1_blm,
        tile_cherryblossom2_blm,
        tile_cherryblossom3_blm,
        icon_magnolia1,
        icon_magnolia2,
        icon_magnolia3,
        tile_canola1_blm,
        tile_canola2_blm,
        tile_canola3_blm,
        tile_mulmangcho1_blm,
        tile_mulmangcho2_blm,
        tile_mulmangcho3_blm,
        tile_napal1_blm,
        tile_napal2_blm,
        tile_napal3_blm,
        tile_rose1_blm,
        tile_rose2_blm,
        tile_rose3_blm,
        tile_silverbell1_blm,
        tile_silverbell2_blm,
        tile_silverbell3_blm,
        tile_sumflower1_blm,
        tile_sumflower2_blm,
        tile_sumflower3_blm,
        tile_tulip_1,
        tile_tulip_2,
        tile_tulip_3,
        tile_violet1_blm,
        tile_violet2,
        tile_violet3_blm,
        tile_rare1_blm,
        tile_rare2_blm,
        tile_rare3_blm,
        tile_rare4_blm,
        tile_rare5_blm,
        tile_rare6_blm,
        MaxCount
    }
   
    public enum FlowerBudConvert  //blm 파일들만 넣어놓기
    {

        tile_cherryblossom1_blm,
        tile_cherryblossom2_blm,
        tile_cherryblossom3_blm,
        icon_magnolia1,
        icon_magnolia2,
        icon_magnolia3,
        tile_canola1_blm,
        tile_canola2_blm,
        tile_canola3_blm,
        tile_mulmangcho1_blm,
        tile_mulmangcho2_blm,
        tile_mulmangcho3_blm,
        tile_napal1_blm,
        tile_napal2_blm,
        tile_napal3_blm,
        tile_rose1_blm,
        tile_rose2_blm,
        tile_rose3_blm,
        tile_silverbell1_blm,
        tile_silverbell2_blm,
        tile_silverbell3_blm,
        tile_sumflower1_blm,
        tile_sumflower2_blm,
        tile_sumflower3_blm,
        tile_tulip_1,
        tile_tulip_2,
        tile_tulip_3,
        tile_violet1_blm,
        tile_violet2,
        tile_violet3_blm,
        tile_rare1_blm,
        tile_rare2_blm,
        tile_rare3_blm,
        tile_rare4_blm,
        tile_rare5_blm,
        tile_rare6_blm,
        MaxCount
    }
    public enum BudFlower
    {
        BudOne,
        BudTwo,
        BudThree,
        BudFour,
        BudFive,
        BudSix,
        MaxCount
    }
    #region 꽃 타일들
    public enum tille_cherryblossom1
    { 
        tille_cherryblossom1_budOne,
        tille_cherryblossom1_budTwo,
        tille_cherryblossom1_budThree,
        tille_cherryblossom1_budFour,
        tille_cherryblossom1_budFive,
        tille_cherryblossom1_budSix,
        tille_cherryblossom1_budSeven,
        tille_cherryblossom1_budEight,
        tille_cherryblossom1_budNine,
        MaxCount
    }
    #endregion
    public enum LeafTypes
    {
        Leaf,
        MaxCount
    }
    public enum WitheredFlowersTileTypes
    {
        tile_withered_flower_blm,
        MaxCount
    }
    public enum BonusTileTypes 
    {
        BonusTileTypes,
        MaxCount
    }
    public enum Items
    {
        Jumper,
        AllBloom,
        //TimeFreeze,
        LeafToFlower,
        Unbeatable,
        PlusLife,
        SkipJumpSwap,
        HideRemainJump,
        MaxCount
    }
    public enum CutScene_prologue
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

        MaxCount
    }

    public enum RandomRewardData
    {
        깽깽이풀,
        주걱댕강나무,
        히어리,
        산작약,
        너도바람꽃,
        금새우난,

        GoldBranch1,
        GoldBranch2,
        GoldBranch3,
        Branch2,
        Branch4,
        Branch6,
        Branch8,

       

    }

}
