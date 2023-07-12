using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tile_cherryblossom3_blm : UI_PopUp
{
    enum Buttons
    {
        Delete,
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {

        base.Init();

        Bind<Button>(typeof(Buttons));

        BindEvent(GetButton((int)Buttons.Delete).gameObject, Btn_Delete);

    }

    #region Buttons

    protected void Btn_Delete(PointerEventData evt)
    {
        ClosePopupUI();
    }

    #endregion

}
