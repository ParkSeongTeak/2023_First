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
        
    }

    public override void Init()
    {
        base.Init();

        //Object ���ε�
        Bind<Button>(typeof(Buttons));

        //Btn�� �̺�Ʈ ����
        BindEvent(GetButton((int)Buttons.Select).gameObject, Btn_Select);
        BindEvent(GetButton((int)Buttons.Save).gameObject, Btn_Save);

    }

    #region Button Event
    
    void Btn_Select(PointerEventData evt)
    {
        GameManager.InGameDataManager.SelectMode = true;
    }
    void Btn_Save(PointerEventData evt)
    {
        GameManager.InGameDataManager.SelectMode = true;

    }
    void Btn_Back(PointerEventData evt)
    {

    }
    #endregion

}
