using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �̰��� ����� Enum���� �����ϴ� �����Դϴ�.
/// �ݵ��! ��� Enum ������ MaxCount �� �������մϴ�.
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
    public enum Sounds
    {
        BGM,
        SFX,
        MaxCount
    }

    /// <summary>
    /// BGM ���ǵ��� �־��ִ� ����
    /// ***�ݵ��****
    /// �뷡�� 
    /// Assets/Resources/Sounds�� �ִ��� Ȯ���ϰ� �߰�����
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
    /// SFX(ȿ����) ���ǵ��� �־��ִ� ����
    /// ***�ݵ��****
    /// �뷡�� 
    /// Assets/Resources/Sounds�� �ִ��� Ȯ���ϰ� �߰�����
    /// </summary>
    public enum SFX
    {
        BlockClear,
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
        �ڽ���,
        ������,
        ����ȭ,

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
        Bonus,
        MaxCount
    }
    public enum Items
    {
        Jumper,
        AllBloom,
        TimeFreeze,
        LeafToFlower,
        Unbeatable,
        PlusLife,
        SkipJumpSwap,
        HideRemainJump,
        MaxCount
    }

}
