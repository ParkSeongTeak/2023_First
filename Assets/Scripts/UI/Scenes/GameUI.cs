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
    GameUI() { }
    ClearRwrdData clearRwrdData = new ClearRwrdData();
    bool _clear = false;
    public bool Clear { get { return _clear; } }

    int jump { get { return clearRwrdData.Jump; } set { clearRwrdData.Jump = value > 0 ? value : 0; ClearCheck(); } }
    int skip { get { return clearRwrdData.Skip; } set { clearRwrdData.Skip = value > 0 ? value : 0; ClearCheck(); } }
    int bloom { get { return clearRwrdData.Bloom; } set { clearRwrdData.Bloom = value > 0 ? value : 0; ClearCheck(); } }
    public int ClearReward_GoldBranch { get { return clearRwrdData.ClearReward_GoldBranch; } }
    void JsonDeepCopy()
    {
        clearRwrdData.Quest = GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Quest;
        clearRwrdData.Jump = GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Jump;
        clearRwrdData.Skip = GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Skip;
        clearRwrdData.Bloom = GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].Bloom;
        clearRwrdData.ClearReward_GoldBranch = GameManager.InGameDataManager.ClearRwrdHandler[GameManager.InGameDataManager.QuestIDX].ClearReward_GoldBranch;

    }



    void ClearCheck()
    {
        if (!_clear)
        {
            if (jump == 0 && skip == 0 && bloom == 0)
            {
                _clear = true;
                GameManager.InGameDataManager.QuestIDX++;
            }
        }
    }

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

        JsonDeepCopy();

        GetText((int)Texts.ScoreTxt).text = $"QUEST: {clearRwrdData.Quest}";
        GetText((int)Texts.JumpCnt).text = $"Jump: {jump}";
        GetText((int)Texts.SkipCnt).text = $"Skip: {skip}";
        GetText((int)Texts.BloomCnt).text = $"Bloom: {bloom}";


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
            GameManager.InGameDataManager.NowState.JumpCnt++;
            jump--;
            GetText((int)Texts.JumpCnt).text = $"Jump: {jump}";
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();
        }
        else
        {
            if (!TileController.IsMoving)
            {
                //Background move��� Action(Delegate �� �������� ����)�� ���� ������ ���� BackGround���� �����ڰ� ó���� ���� �� �� �ش�.
                TileController.Instance.BackGroundMove?.Invoke();
                GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Skip();
                GameManager.InGameDataManager.NowState.SkipCnt++;
                skip--;
                GetText((int)Texts.SkipCnt).text = $"Skip: {skip}";

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
                GameManager.InGameDataManager.NowState.SkipCnt++;
                skip--;
                GetText((int)Texts.SkipCnt).text = $"Skip: {skip}";

                TileController.Instance.MoveTiles();

            }
        }
        else
        {
            Debug.Log("JumpBtn����");

            GameManager.InGameDataManager.NowState.JumpCnt++;
            jump--;
            GetText((int)Texts.JumpCnt).text = $"Jump: {jump}";
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();
        }

    }

    public void BloomCnt()
    {
        GameManager.InGameDataManager.NowState.BloomCnt++;
        bloom--;
        GetText((int)Texts.BloomCnt).text = $"BloomCnt: {bloom}";

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

        if (SkipJumpSwapItemIcon == null)   //�ߺ� ���� ����
        {
            SkipJumpSwapItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_SkipJumpSwap");
        }

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

        if (Obstacle == null)   //�ߺ� ���� ����
        {
            Obstacle = GameManager.ResourceManager.Instantiate("ItemTypes/obstacle");
        }


        yield return new WaitForSecondsRealtime(_hideTime);

        isHideActive = false;

        if (Obstacle != null)
        {
            Destroy(Obstacle);
        }
    }


    #region UnbeatableItem

    public float unbeatableDuration = 10f; // ���� ���� �ð�
    private bool isUnbeatable;//bool ����
    private float originalGravityScale;
    private Rigidbody2D WingWingRigidbody;
    GameObject UnbeatableItemIcon;

    public void Unbeatable()
    {
        Debug.Log("Unbeatable() ����");
        if (isUnbeatable == false)
        {
            isUnbeatable = true;

            WingWingRigidbody = GameManager.InGameDataManager.Player.GetComponent<Rigidbody2D>();
            originalGravityScale = WingWingRigidbody.gravityScale; //originalGravityScale�� Unbeatable() �Լ��� ó���� wingWingRigidbody.gravityScale ���� �����ϴµ� ���

            Debug.Log("FreezeYPosition() ����");
            FreezeYPosition();// FreezeYPosition�Լ� ����

            Debug.Log("�ڷ�ƾ ����");
            //WingWingRigidbody.gravityScale = 0f;//������ �߷� 0���� ����
            //StartCoroutine(ResumeUnbeatableAfterDelay(unbeatableDuration));
            //10�� �ڿ� �ڷ�ƾ ����
        }

    }

    public void FreezeYPosition()//�ʹ����� �̻��� �Լ� �ٽ� ����� �ٶ�
    {
        Vector3 currentPosition = GameManager.InGameDataManager.Player.transform.position; //�������� ���� ��ġ
        currentPosition.y = -1.483448f;//��ġ ����
        GameManager.InGameDataManager.Player.transform.position = currentPosition;
    }//is Unbeatable=false�� �Ǹ� y�� ������ ���� ������
   

    private IEnumerator ResumeUnbeatableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        WingWingRigidbody.gravityScale = originalGravityScale;//������ ���� �߷�(4)���� ����
        UnbeatableItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_Unbeatable");//������ ����
        UnbeatableItemIcon.SetActive(true);

        isUnbeatable = false;
        UnbeatableItemIcon.SetActive(false);//������ ����
    }

    /*
    public void OnTriggerStay2D(Collider2D collision)
    {
        // Unbeatable �������� �ٸ� �����ۺ��� �켱 ����Ǵ� ���
        if (isUnbeatable == true)
        {
            // �ش� �������� Unbeatable �������� �ƴ϶��
            if (!collision.gameObject.CompareTag("Unbeatable"))
            {
                collision.enabled = false; // �ش� ������ ȿ�� X
            }
        }
    }

    */

    public void PlusTime()
    { 


    }

}


#endregion  UnbeatableItem


#endregion HideRemainJumpItem