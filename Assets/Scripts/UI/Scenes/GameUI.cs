using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class GameUI : UI_Scene
{
    public static GameUI Instance { get; private set; }
    GameUI() { }


    #region Data
    Animator _animator;
    bool isAnim = false;
    ClearRwrdData clearRwrdData = new ClearRwrdData();
    bool _clear = false;
    public bool Clear { get { return _clear; } }
    TimeSlider _timeSlider;
    public TimeSlider timeSlider { get { return _timeSlider; } }
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

    Vector3 jumpVec;
    Vector3 skipVec;

    #endregion Data





    void Start()
    {
        _animator = Util.FindChild<Animator>(gameObject, "PlayerAnim");
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
        
        _timeSlider = Util.FindChild(gameObject, "Timeslider", true).GetComponent<TimeSlider>();

        jumpVec = GetButton((int)Buttons.JumpBtn).transform.position;
        skipVec = GetButton((int)Buttons.SkipBtn).transform.position;

    }

    public bool isJumpActive { get; set; } = true;
    public bool isSkipActive { get; set; } = true;


    GameObject Lifeicon;
    public GameObject LifeIcon { get { return Lifeicon; } set { Lifeicon = value; } }



    void Btn_Jump(PointerEventData evt)
    {

        // ������ ������ �Ǵ� ��Ȳ ������! ���� ���尡 ���°� �³�?
        // ��ư�� ������ ������ ����� ���� ������ �ǳ� ���Ĵ� ���� �˹ٴ� �ƴϴ�. 

        GameManager.SoundManager.Play(Define.SFX.Jump_01);



        Debug.Log("JumpBtn����");
        GameManager.InGameDataManager.NowState.JumpCnt++;
        jump--;
        GetText((int)Texts.JumpCnt).text = $"Jump: {jump}";
        GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();

        //��ư ��ü�� ��ġ�� �ٲٴ� �� �´´ٰ� �մϴ�.
        /*
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
        */


    }
    void Btn_Skip(PointerEventData evt)
    {

        GameManager.SoundManager.Play(Define.SFX.Skip_01);

        //��ư ��ü�� ��ġ�� �ٲٴ� �� �´´ٰ� �մϴ�.
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
        //��ư ��ü�� ��ġ�� �ٲٴ� �� �´´ٰ� �մϴ�.
        /*
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
        */

    }

    /// <summary>
    /// Quest UI���� + ��ü Data ���� + Bloom�� �ð� �߰� 
    /// </summary>
    /// <param name="plusTime_bloom"></param>
    public void BloomCnt(float plusTime_bloom = 0.05f)
    {

        GameUI.Instance.timeSlider.PlusTime(plusTime_bloom);
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
            _timeSlider.StopTimer();
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

        _timeSlider.ResetSpeed();

        Debug.Log("END TimeFreezeItem ");

    }

    #endregion TimeFreezeItem

    #region SkipJumpSwapItem

    private bool isSkipJumpSwapEffectActive = false;
    private Coroutine SkipJumpSwapItemCoroutine;
    GameObject SkipJumpSwapItemIcon;

    float _swapTime = 10.0f;


    public void SkipJumpSwapItem()
    {
        if (isSkipJumpSwapEffectActive == false)    //ȿ�� �����߾ƴ�  
        {
            isSkipJumpSwapEffectActive = true;
            //isJumpActive = false;
            //isSkipActive = false;

            SkipJumpSwapItemCoroutine = StartCoroutine(isCounting());
        }
        else
        {

            StopCoroutine(SkipJumpSwapItemCoroutine);

            Debug.Log("�����");

            isSkipJumpSwapEffectActive = true;
            //isJumpActive = false;
            //isSkipActive = false;

            SkipJumpSwapItemCoroutine = StartCoroutine(isCounting());

        }
    }


    /// <summary>
    /// ��ư ��� 10��? �� �ٲ�
    /// </summary>
    /// <returns></returns>
    private IEnumerator isCounting()
    {

        if (SkipJumpSwapItemIcon == null)   //�ߺ� ���� ����
        {
            SkipJumpSwapItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_SkipJumpSwap");
        }

        GetButton((int)Buttons.JumpBtn).transform.position = skipVec;
        GetButton((int)Buttons.SkipBtn).transform.position = jumpVec;


        SkipJumpSwapItemIcon.SetActive(true);

        yield return new WaitForSecondsRealtime(_swapTime);

        isSkipJumpSwapEffectActive = false;


        //isJumpActive = true;
        //isSkipActive = true;

        SkipJumpSwapItemIcon.SetActive(false);

        GetButton((int)Buttons.JumpBtn).transform.position = jumpVec;
        GetButton((int)Buttons.SkipBtn).transform.position = skipVec;
    }

    #endregion SkipJumpSwapItem

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


    #endregion HideRemainJumpItem

    #region UnbeatableItem

    public float unbeatableDuration = 10f; // ���� ���� �ð�
    //public bool isUnbeatable;//bool ����
    bool _isUnbeatable = false;
    public bool isUnbeatable { get { return _isUnbeatable; } }
    GameObject UnbeatableItemIcon { get; set; }
    Coroutine UnbeatCoroutine;
    /// <summary>
    /// ���� ������ Ȱ��ȭ
    /// </summary>
    public void Unbeatable()
    {
        Debug.Log("Unbeatable() ����");
        if (_isUnbeatable == false)
        {
            _isUnbeatable = true;
            UnbeatCoroutine = StartCoroutine(ResumeUnbeatableAfterDelay());

            //10�� �ڿ� �ڷ�ƾ ����
        }
        else
        {

            StopCoroutine(UnbeatCoroutine);
            _isUnbeatable = true;
            UnbeatCoroutine = StartCoroutine(ResumeUnbeatableAfterDelay());
        }

    }

    private IEnumerator ResumeUnbeatableAfterDelay(float delay = 10f)
    {

        _timeSlider.StopTimer();
        GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Unbeatable(delay+3);
        GameManager.InGameDataManager.NowUnbeat = true;
        if(UnbeatableItemIcon== null)
        {
            UnbeatableItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_Unbeatable");//������ ����
        }
        UnbeatableItemIcon.SetActive(true);

        yield return new WaitForSeconds(delay);

        _timeSlider.ResetSpeed();
        _isUnbeatable = false;
        GameManager.InGameDataManager.NowUnbeat = false;
        UnbeatableItemIcon.SetActive(false);//������ ����
        GameManager.InGameDataManager.Player.GetComponent<PlayerController>().UnbeatableEnd();
    }


    public void PlusTime()
    { 


    }



    #endregion  UnbeatableItem

    #region JumperItem
    Coroutine JumperItem;
    public  void Jumper()
    {

        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump(35f,true);

            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;
            JumperItem = StartCoroutine(DontFall());
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Skip();
            for (int i = 3; i <= 13; i++)
            {
                ///?? �� 3���� ��� �����ϳ���? 1) [3]�� �����̰� �ö� �ִ�  tile + GoTo 2)
                Tile tile = nowGeneratedTiles[3];

                TileController.Instance.BackGroundMove?.Invoke();
                GameManager.InGameDataManager.NowState.SkipCnt++;
                skip--;
                GetText((int)Texts.SkipCnt).text = $"Skip: {skip}";


                if (tile.TileType == Define.TileType.FlowerTypes)
                {
                    // UI���� ���� �ʿ�
                    //GameUI.Instance.BloomCnt();

                }
                else if (tile.TileType == Define.TileType.BonusTileTypes)
                {
                    //after confirm
                }
                // 2) �� �Լ����� List �� �� �� [0]���� ���� �� ��ü List�� index �� ��ĭ ������ �̵� == �� �Լ� ȣ�� ���� ������ �� [3]�� ���� list�� [4]
                TileController.Instance.MoveTiles();    
            }
        }

    }


    IEnumerator DontFall()
    {
        //GameManager.InGameDataManager.Player.transform.position = GameManager.InGameDataManager.Player.transform.position + new Vector3(0, 0.15f, 0);
        GameManager.InGameDataManager.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;// | RigidbodyConstraints2D.FreezePositionY; 
        GameManager.InGameDataManager.Player.tag = "Untagged";
        yield return new WaitForSeconds(PlayerController.SPEED + 0.1f);

        
        GameManager.InGameDataManager.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        //GameManager.InGameDataManager.Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        GameManager.InGameDataManager.Player.tag = "WingWing";

    }
    #endregion JumperItem

    #region PlusLifeItem
    public GameObject PlusLifeItemIcon { get; set; }

    public void PlusLifeItem()
    {
        if (GameManager.InGameDataManager.NowState.LifeCnt == 1)
        {
            if (PlusLifeItemIcon == null)   //�ߺ� ���� ����
            {
                PlusLifeItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/Icon_pluslife");
            }
            GameManager.InGameDataManager.NowState.LifeCnt = 2;
            PlusLifeItemIcon.SetActive(true);


        }


    }

    #endregion PlusLifeItem

    #endregion ItemEffect Area


}

