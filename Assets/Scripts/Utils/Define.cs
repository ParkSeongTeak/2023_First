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
    /// State Machine 0.2% �� �������Ѻ��ô�.
    /// </summary>
    public enum States
    {
        Play,
        Pause,
        Win,
        Lose,
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

        MaxCount
    }

}
