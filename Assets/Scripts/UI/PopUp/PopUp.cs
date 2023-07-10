using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_PopUp : UI_Base
{
    public override void Init()
    {
        GameManager.UIManager.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        GameManager.UIManager.ClosePopupUI(this);
    }
}
