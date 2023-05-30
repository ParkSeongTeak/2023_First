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
        PlayRwrd,
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
    public enum FlowerTypes
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
    public enum LeafTypes
    {
        �о粢��,
        ����,
        MaxCount
    }
    public enum WitheredFlowersTileTypes
    {
        �õ��,
        �õ��2,
        MaxCount
    }
    public enum BonusTileTypes 
    {
        Bonus,
        MaxCount
    }


}
