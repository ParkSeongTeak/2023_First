using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUI : UI_Scene
{
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

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object 바인드
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        //Btn에 이벤트 연결
        BindEvent(GetButton((int)Buttons.JumpBtn).gameObject, Btn_Jump);
        BindEvent(GetButton((int)Buttons.SkipBtn).gameObject, Btn_Skip);


    }

    void Btn_Jump(PointerEventData evt)
    {
        Debug.Log("JumpBtn눌림");

        GetText((int)Texts.JumpCnt).text = $"Jump: {GameManager.InGameDataManager.NowState.JumpCnt++}";
        GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();

    }
    void Btn_Skip(PointerEventData evt)
    {
        if (!TileController.IsMoving)
        {
            //Background move라는 Action(Delegate 즉 대행자의 일종)에 값이 있으면 실행 BackGround에서 대행자가 처리할 일을 더 해 준다.
            TileController.Instance.BackGroundMove?.Invoke();
            GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Skip();
            GetText((int)Texts.SkipCnt).text = $"Skip: {GameManager.InGameDataManager.NowState.SkipCnt++}";
            TileController.Instance.MoveTiles();

        }
    }
}
