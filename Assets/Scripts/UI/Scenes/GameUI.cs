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

        //Object ���ε�
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        //Btn�� �̺�Ʈ ����
        BindEvent(GetButton((int)Buttons.JumpBtn).gameObject, Btn_Jump);
        BindEvent(GetButton((int)Buttons.SkipBtn).gameObject, Btn_Skip);


    }

    void Btn_Jump(PointerEventData evt)
    {
        Debug.Log("JumpBtn����");

        GetText((int)Texts.JumpCnt).text = $"Jump: {GameManager.InGameDataManager.NowState.JumpCnt++}";
        GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Jump();

    }
    void Btn_Skip(PointerEventData evt)
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
