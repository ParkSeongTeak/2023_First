using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlowerBook : UI_PopUp
{


    protected int branch;
    protected int goldBranch;

    protected int have;

    public virtual int GetBranch()
    {
        return branch;
    }
    public virtual int GetGoldBranch()
    {
        return goldBranch;
    }

    enum Buttons
    {
        Delete,
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void ShowPrice()
    {
        System.Type tmpClassType = this.GetType();
        branch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].Branch;
        goldBranch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].GoldBranch;

        Debug.Log($"{tmpClassType.Name} : branch: {branch}    goldBranch: {goldBranch}");

    }
    public override void Init()
    {

        base.Init();

        Bind<Button>(typeof(Buttons));
        BindEvent(GetButton((int)Buttons.Delete).gameObject, Btn_Delete);
        
        System.Type tmpClassType = this.GetType();
        branch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].Branch;
        goldBranch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].GoldBranch;

        Debug.Log($"{tmpClassType.Name} : branch: {branch}    goldBranch: {goldBranch}");


        have = PlayerPrefs.GetInt($"{tmpClassType.Name}Have", 0); 
        

    }

    #region Buttons

    protected void Btn_Delete(PointerEventData evt)
    {
        ClosePopupUI();
    }

    #endregion
}
