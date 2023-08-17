using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �̰��� ����� Enum���� �����ϴ� �����Դϴ�.
/// �ݵ��! ��� Enum ������ MaxCount �� �������մϴ�.
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
    /// ����� ��� Button�� "�̸�"�� �̰��� ������ 
    /// ***����*** �̰��� ��ư�� �̸��� ���� ��ư �̸��� �ٸ��� �ȵ�
    /// ��ư�� �̸��� �ٲٸ� �ݵ��!!!!!! �̰������� �̸��� �����ϰ� �����������
    /// </summary>
    public enum Buttons
    {

        JumpBtn,
        SkipBtn,
        MaxCount
    }
    /// <summary>
    /// ����� ��� Text�� "�̸�"�� �̰��� ������ 
    /// ***����*** �̰��� Text�� �̸��� ���� ��ư �̸��� �ٸ��� �ȵ�
    /// Text�� �̸��� �ٲٸ� �ݵ��!!!!!! �̰������� �̸��� �����ϰ� �����������
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
    /// Images�� ��Ʈ�� ����� �ϴ� �ֵ鸸 �˾Ƽ� ������ �����սô�. 
    /// �ʹ��� �翬������ ��Ʈ�� ����� �ϴ� �̹����� �̸��� ���ƾ��մϴ�.
    /// </summary>
    public enum Images
    {
        flowerImg,
        MaxCount
    }



    /// <summary>
    /// �ǵ��� ����
    /// </summary>
    public enum Sounds
    {
        BGM,
        SFX,
        MaxCount
    }


    //////////////////////////////////////////////////////////////////////
    /// <summary>
    /// BGM ���ǵ��� �־��ִ� ����
    /// ***�ݵ��****
    /// �뷡�� 
    /// Assets/Resources/Sounds�� �ִ��� Ȯ���ϰ� �߰�����
    /// </summary>
    
    public enum BGM //loop O
    {
        ����_�ɵ���,
        �������۴�_01,
        MaxCount
    }

    /// <summary>
    /// SFX(ȿ����) ���ǵ��� �־��ִ� ����
    /// ***�ݵ��****
    /// �뷡�� 
    /// Assets/Resources/Sounds�� �ִ��� Ȯ���ϰ� �߰�����
    /// </summary>
    public enum SFX // loop X
    {
        Skip_01,//����UI ��ũ��Ʈ
        Jump_01,//����UI ��ũ��Ʈ
        Bee_01,//����
        Bloom_01,//��
        click_01,//��
        Start_01,//MainUI���� ���
        click_02,//
        congrats_01,//MainUI���� ���
        /*congrats02_01,
        congrats02_02,*///����> ��� ����X
        congrats02_03,//Shop UI������� ��
        Error_01,//Shop UI������� ��
        Falling_01,//����
        Falling_02,//WitheredFlowerTile���� ���
        GameOver_01,//Ÿ�ӽ����̵� ��ũ��Ʈ���� ��� 
        GlassBreak,//�÷��������������� ��ũ��Ʈ���� ���
        //Mumble_01,�ϵ��� �����Ƿ� ���X
        Page_01,//Pag_01,02,03���� ���

        MaxCount
    }

    //////////////////////////////////////////////////////////////////////

    public enum PopUpUI
    {
        GameOverMenu,
        MaxCount
    }
    
    /// <summary>
    /// �ɺ����� Ÿ�� :   FlowerBudTile
    /// �� Ÿ�� :         LeafTile 
    /// �õ� �� Ÿ�� :    WitheredFlowersTile
    /// ���ʽ� Ÿ�� :     BonusTile
    /// </summary>
    public enum TileType
    {
        FlowerTypes,
        LeafTypes,
        WitheredFlowersTileTypes,
        BonusTileTypes,
        MaxCount

    }
    public enum FlowerTypes  //blm ���ϵ鸸 �־����
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
   
    public enum FlowerBudConvert  //blm ���ϵ鸸 �־����
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
    #region �� Ÿ�ϵ�
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
        ������Ǯ,
        �ְƴ󰭳���,
        ���,
        ���۾�,
        �ʵ��ٶ���,
        �ݻ��쳭,

        GoldBranch1,
        GoldBranch2,
        GoldBranch3,
        Branch2,
        Branch4,
        Branch6,
        Branch8,

       

    }

}
