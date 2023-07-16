using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class FlowersBookUI : UI_Scene
{
    enum Buttons
    {
        Select,
        Save,
        Back,
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object 바인드
        Bind<Button>(typeof(Buttons));

        //Btn에 이벤트 연결
        BindEvent(GetButton((int)Buttons.Select).gameObject, Btn_Select);
        BindEvent(GetButton((int)Buttons.Save).gameObject, Btn_Save);

    }

    #region Button Event
    
    void Btn_Select(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState = GameManager.InGameDataManager.bookSelect;
        Debug.Log("??");
    }
    void Btn_Save(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState = GameManager.InGameDataManager.bookInfo;

    }
    void Btn_Back(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState = GameManager.InGameDataManager.bookInfo;
        GameManager.SceneManager.LoadScene(Define.Scenes.Game);

    }
    #endregion

}
