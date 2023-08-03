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
        //Object 바인드
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        //Btn에 이벤트 연결
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
            Debug.Log("JumpBtn눌림");
            GameManager.InGameDataManager.NowState.JumpCnt++;
            jump--;
            GetText((int)Texts.JumpCnt).text = $"Jump: {jump}";
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();
        }
        else
        {
            if (!TileController.IsMoving)
            {
                //Background move라는 Action(Delegate 즉 대행자의 일종)에 값이 있으면 실행 BackGround에서 대행자가 처리할 일을 더 해 준다.
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
                //Background move라는 Action(Delegate 즉 대행자의 일종)에 값이 있으면 실행 BackGround에서 대행자가 처리할 일을 더 해 준다.
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
            Debug.Log("JumpBtn눌림");

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
        if (isTimeFrozen == false) //만약 istumefrozen이 작동할 수 없다면
        {
            TimeSlider.StopTimer();
            isTimeFrozen = true;// 시간을 얼리는 조건 true로 변경
            TimeFreezeCoroutine = StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//코루틴 실행

        }
        else //갱신 지금부터 4초
        {
            StopCoroutine(TimeFreezeCoroutine);
            TimeFreezeCoroutine = StartCoroutine(ResumeTimeAfterDelay(freezeDuration));//코루틴 실행
        }

    }

    private IEnumerator ResumeTimeAfterDelay(float delay)//5초 뒤에 작동
    {
        yield return new WaitForSeconds(delay);  //  변경된 부분>> WaitForSeconds를 사용하도록 변경/
                                                 //  WaitForSeconds(5.0f); >5초 동안 멈춘 후 메세지 출력(timescale의 영향 받지X)

        //originalValue = slider.value;//s.v를 o.v값에 대입>>그러므로 ov는 슬라이더가 멈춰도 이전의 값을 기억하게 됨.
        //
        //slider.interactable = false; //아이템 작동 기간 동안 Slider의 상호작용 중지(슬라이더 멈추는 것)
        isTimeFrozen = false; // 변경된 부분>> 시간멈춤을 해제할 때 isTimeFrozen을 false로 변경
        //slider.interactable = true;//아이템 작동 후 다시 Slider 상호작용0

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
        if (isEffectActive == false)    //효과 적용중아님  
        {
            isEffectActive = true;
            isJumpActive = false;
            isSkipActive = false;

            SkipJumpSwapItemCoroutine = StartCoroutine(isCounting());
        }
        else
        {

            StopCoroutine(SkipJumpSwapItemCoroutine);

            Debug.Log("재시작");

            isEffectActive = true;
            isJumpActive = false;
            isSkipActive = false;

            SkipJumpSwapItemCoroutine = StartCoroutine(isCounting());

        }
    }


    /// <summary>
    /// 버튼 기능 10초? 간 바뀜
    /// </summary>
    /// <returns></returns>
    private IEnumerator isCounting()

    {
        Debug.Log("시작");

        if (SkipJumpSwapItemIcon == null)   //중복 생성 방지
        {
            SkipJumpSwapItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_SkipJumpSwap");
        }

        SkipJumpSwapItemIcon.SetActive(true);

        yield return new WaitForSecondsRealtime(_swapTime);

        Debug.Log("끝");
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
        if (isHideActive == false)    //효과 적용중아님  
        {
            isHideActive = true;

            HideRemainJumpItemCoroutine = StartCoroutine(HideTile());
        }
        else    //효과 적용 중
        {

            StopCoroutine(HideRemainJumpItemCoroutine);
            HideRemainJumpItemCoroutine = StartCoroutine(HideTile());

        }
    }

    /// <summary>
    /// 시야 방해물이 5초간 나타남
    /// </summary>
    private IEnumerator HideTile()

    {

        if (Obstacle == null)   //중복 생성 방지
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

    public float unbeatableDuration = 10f; // 무적 지속 시간
    private bool isUnbeatable;//bool 설정
    private float originalGravityScale;
    private Rigidbody2D WingWingRigidbody;
    GameObject UnbeatableItemIcon;

    public void Unbeatable()
    {
        Debug.Log("Unbeatable() 시작");
        if (isUnbeatable == false)
        {
            isUnbeatable = true;

            WingWingRigidbody = GameManager.InGameDataManager.Player.GetComponent<Rigidbody2D>();
            originalGravityScale = WingWingRigidbody.gravityScale; //originalGravityScale은 Unbeatable() 함수의 처음에 wingWingRigidbody.gravityScale 값을 저장하는데 사용

            Debug.Log("FreezeYPosition() 실행");
            FreezeYPosition();// FreezeYPosition함수 실행

            Debug.Log("코루틴 시작");
            //WingWingRigidbody.gravityScale = 0f;//윙윙이 중력 0으로 설정
            //StartCoroutine(ResumeUnbeatableAfterDelay(unbeatableDuration));
            //10초 뒤에 코루틴 실행
        }

    }

    public void FreezeYPosition()//너무나도 이상한 함수 다시 만들기 바람
    {
        Vector3 currentPosition = GameManager.InGameDataManager.Player.transform.position; //윙윙이의 현재 위치
        currentPosition.y = -1.483448f;//위치 고정
        GameManager.InGameDataManager.Player.transform.position = currentPosition;
    }//is Unbeatable=false가 되면 y축 고정도 같이 해제됨
   

    private IEnumerator ResumeUnbeatableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        WingWingRigidbody.gravityScale = originalGravityScale;//윙윙이 원래 중력(4)으로 복구
        UnbeatableItemIcon = GameManager.ResourceManager.Instantiate("ItemTypes/icon_Unbeatable");//아이콘 띄우기
        UnbeatableItemIcon.SetActive(true);

        isUnbeatable = false;
        UnbeatableItemIcon.SetActive(false);//아이콘 제거
    }

    /*
    public void OnTriggerStay2D(Collider2D collision)
    {
        // Unbeatable 아이템이 다른 아이템보다 우선 적용되는 경우
        if (isUnbeatable == true)
        {
            // 해당 아이템이 Unbeatable 아이템이 아니라면
            if (!collision.gameObject.CompareTag("Unbeatable"))
            {
                collision.enabled = false; // 해당 아이템 효과 X
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