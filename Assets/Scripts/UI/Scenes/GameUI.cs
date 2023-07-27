using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUI : UI_Scene
{
    public static GameUI Instance { get; private set; }

    enum Buttons
    {
        JumpBtn,
        SkipBtn,
    }

    enum Texts
    {
        ScoreTxt,
        JumpCnt,
        SkipCnt,
        BloomCnt,
    }

    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        if (Instance == null)
        {
            Instance = this;
        }
        //Object ���ε�
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        //Btn�� �̺�Ʈ ����
        BindEvent(GetButton((int)Buttons.JumpBtn).gameObject, Btn_Jump);
        BindEvent(GetButton((int)Buttons.SkipBtn).gameObject, Btn_Skip);


    }

    public bool isJumpActive { get; set; } = true;
    public bool isSkipActive { get; set; } = true;


    GameObject Lifeicon;
    public GameObject LifeIcon { get { return Lifeicon; } set { Lifeicon = value; } }



    void Btn_Jump(PointerEventData evt)
    {

        if (isJumpActive)
        {
            Debug.Log("JumpBtn����");

            GetText((int)Texts.JumpCnt).text = $"Jump: {GameManager.InGameDataManager.NowState.JumpCnt++}";
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();
        }
        else
        {
            if (!TileController.IsMoving)
            {
                //Background move��� Action(Delegate �� �������� ����)�� ���� ������ ���� BackGround���� �����ڰ� ó���� ���� �� �� �ش�.
                TileController.Instance.BackGroundMove?.Invoke();
                GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Skip();
                GetText((int)Texts.SkipCnt).text = $"Skip: {GameManager.InGameDataManager.NowState.SkipCnt++}";
                TileController.Instance.MoveTiles();

            }
        }


    }
    void Btn_Skip(PointerEventData evt)
    {

        if (isSkipActive)
        {
            if (!TileController.IsMoving)
            {
                //Background move��� Action(Delegate �� �������� ����)�� ���� ������ ���� BackGround���� �����ڰ� ó���� ���� �� �� �ش�.
                TileController.Instance.BackGroundMove?.Invoke();
                GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Skip();
                GetText((int)Texts.SkipCnt).text = $"Skip: {GameManager.InGameDataManager.NowState.SkipCnt++}";
                TileController.Instance.MoveTiles();

            }
        }
        else
        {
            Debug.Log("JumpBtn����");

            GetText((int)Texts.JumpCnt).text = $"Jump: {GameManager.InGameDataManager.NowState.JumpCnt++}";
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();
        }

    }

    #region ItemEffect Area


    #region TimeFreezeItem

    public float freezeDuration = 5f;
    private bool isTimeFrozen = false;
    Coroutine TimeFreezeCoroutine;

    public void TimeFreeze()
    {
        Debug.Log("TimeFreezeSTart");
        if (isTimeFrozen == false) //���� istumefrozen�� �۵��� �� ���ٸ�
        {
            TimeSlider.StopTimer();
            isTimeFrozen = true;// �ð��� �󸮴� ���� true�� ����
            TimeFreezeCoroutine = StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//�ڷ�ƾ ����

        }
        else //���� ���ݺ��� 4��
        {
            StopCoroutine(TimeFreezeCoroutine);
            TimeFreezeCoroutine = StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//�ڷ�ƾ ����
        }

    }

    private IEnumerator ResumeTimeAfterDelay(float delay)//5�� �ڿ� �۵�
    {
        yield return new WaitForSeconds(delay);  //  ����� �κ�>> WaitForSeconds�� ����ϵ��� ����/
                                                 //  WaitForSeconds(5.0f); >5�� ���� ���� �� �޼��� ���(timescale�� ���� ����X)

        //originalValue = slider.value;//s.v�� o.v���� ����>>�׷��Ƿ� ov�� �����̴��� ���絵 ������ ���� ����ϰ� ��.
        //
        //slider.interactable = false; //������ �۵� �Ⱓ ���� Slider�� ��ȣ�ۿ� ����(�����̴� ���ߴ� ��)
        isTimeFrozen = false; // ����� �κ�>> �ð������� ������ �� isTimeFrozen�� false�� ����
        //slider.interactable = true;//������ �۵� �� �ٽ� Slider ��ȣ�ۿ�0

        TimeSlider.ResetSpeed();

        Debug.Log("END TimeFreezeItem ");

    }

    #endregion TimeFreezeItem


    #region SkipJumpSwapItem

    private bool isEffectActive = false;
    private Coroutine SkipJumpSwapItemCoroutine;
    GameObject SkipJumpSwapItemIcon;

    float _swapTime = 10.0f;


    public void SkipJumpSwapItem()
    {
        if (isEffectActive == false)    //ȿ�� �����߾ƴ�  
        {
            isEffectActive = true;
            isJumpActive = false;
            isSkipActive = false;

            SkipJumpSwapItemCoroutine = StartCoroutine(isCounting());
        }
        else
        {

            StopCoroutine(SkipJumpSwapItemCoroutine);

            Debug.Log("�����");

            isEffectActive = true;
            isJumpActive = false;
            isSkipActive = false;

            SkipJumpSwapItemCoroutine = StartCoroutine(isCounting());

        }
    }


    /// <summary>
    /// ��ư ��� 10��? �� �ٲ�
    /// </summary>
    /// <returns></returns>
    private IEnumerator isCounting()

    {
        Debug.Log("����");

        SkipJumpSwapItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_SkipJumpSwap");

        SkipJumpSwapItemIcon.SetActive(true);

        yield return new WaitForSecondsRealtime(_swapTime);

        Debug.Log("��");
        isEffectActive = false;


        isJumpActive = true;
        isSkipActive = true;

        SkipJumpSwapItemIcon.SetActive(false);

    }

    #endregion SkipJumpSwapItem

    #endregion ItemEffect Area


    ///
    #region HideRemainJumpItem

    private bool isHideActive = false;
    Coroutine HideRemainJumpItemCoroutine;
    GameObject HideRemainJumpItemIcon;
    GameObject Obstacle;

    float _hideTime = 5.0f;


    public void HideRemainJumpItem()
    {
        if (isHideActive == false)    //ȿ�� �����߾ƴ�  
        {
            isHideActive = true;

            HideRemainJumpItemCoroutine = StartCoroutine(HideTile());
        }
        else    //ȿ�� ���� ��
        {

            StopCoroutine(HideRemainJumpItemCoroutine);
            HideRemainJumpItemCoroutine = StartCoroutine(HideTile());

        }
    }


    /// <summary>
    /// �þ� ���ع��� 5�ʰ� ��Ÿ��
    /// </summary>
    private IEnumerator HideTile()

    {

        HideRemainJumpItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_HideRemainJump");

        if (Obstacle == null)   //�ߺ� ���� ����
        {
            Obstacle = GameManager.ResourceManager.Instantiate("ItemTypes/obstacle");
        }

        HideRemainJumpItemIcon.SetActive(true);

        yield return new WaitForSecondsRealtime(_hideTime);

        isHideActive = false;
        HideRemainJumpItemIcon.SetActive(false);

        if (Obstacle != null)
        {
            Destroy(Obstacle);
        }
    }


}

#endregion HideRemainJumpItem