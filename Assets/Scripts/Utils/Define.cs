using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이곳은 사용할 Enum만을 관리하는 영역입니다.
/// 반드시! 모든 Enum 끝에는 MaxCount 로 끝내야합니다.
/// </summary>
public class Define 
{
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
        PlayRwrd,
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
    public enum Sounds
    {
        BGM,
        SFX,
        MaxCount
    }

    /// <summary>
    /// BGM 음악들을 넣어주는 공간
    /// ***반드시****
    /// 노래가 
    /// Assets/Resources/Sounds에 있는지 확인하고 추가하자
    /// </summary>
    public enum BGM
    {
        BlockBgm,
        MaxCount
    }


    public enum PopUpUI
    {
        GameOverMenu,
        MaxCount
    }
    /// <summary>
    /// SFX(효과음) 음악들을 넣어주는 공간
    /// ***반드시****
    /// 노래가 
    /// Assets/Resources/Sounds에 있는지 확인하고 추가하자
    /// </summary>
    public enum SFX
    {
        BlockClear,
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
    public enum FlowerTypes
    {
        코스모스,
        개나리,
        무궁화,

        MaxCount
    }
    public enum CosmosFlower
    {
        CosmosOne,
        CosmosTwo,
        CosmosThree,
        CosmosFour,
        CosmosFive,
        CosmosSix,
        MaxCount
    }
    public enum LeafTypes
    {
        밀양깻잎,
        상추,
        MaxCount
    }
    public enum WitheredFlowersTileTypes
    {
        시든꽃,
        시든꽃2,
        MaxCount
    }
    public enum BonusTileTypes 
    {
        Bonus,
        MaxCount
    }


}
