using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;
using static Unity.Burst.Intrinsics.X86.Avx;

public abstract class FlowerBook : UI_PopUp
{

    FlowerButton _myFlowerButton;
    Define.FlowerTypes _flowerType;
    protected int _branch;
    protected int _goldBranch;

    protected int have;

    public virtual int GetBranch()
    {
        return _branch;
    }

    public abstract Define.FlowerTypes GetFlowerType();

    public void SetMyFlowerButton(FlowerButton myFlowerButton)
    {
        _myFlowerButton = myFlowerButton;
    }

    public void BuyIt()
    {

        System.Type tmpClassType = this.GetType();
        PlayerPrefs.SetInt($"{tmpClassType.Name}Have", 1);
        have = 1;
        _myFlowerButton.UIUpdate();


    }
    public bool GetHave()
    {
        System.Type tmpClassType = this.GetType();

        return PlayerPrefs.GetInt($"{tmpClassType.Name}Have", 0) > 0;
    }

    public virtual int GetGoldBranch()
    {
        return _goldBranch;
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
        _branch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].Branch;
        _goldBranch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].GoldBranch;

        Debug.Log($"{tmpClassType.Name} : branch: {_branch}    goldBranch: {_goldBranch}");

    }
    public override void Init()
    {
        base.Init();
        _flowerType = (FlowerTypes)Enum.Parse(typeof(FlowerTypes), this.GetType().Name);


        Bind<Button>(typeof(Buttons));
        BindEvent(GetButton((int)Buttons.Delete).gameObject, Btn_Delete);


        
        System.Type tmpClassType = this.GetType();
        _branch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].Branch;
        _goldBranch = GameManager.InGameDataManager.FlowerPriceHandler[tmpClassType.Name].GoldBranch;


        have = PlayerPrefs.GetInt($"{tmpClassType.Name}Have", 0); 
       

    }

    #region Buttons

    protected void Btn_Delete(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_01);//click_01È¿°úÀ½
        ClosePopupUI();
    }

    #endregion
}
