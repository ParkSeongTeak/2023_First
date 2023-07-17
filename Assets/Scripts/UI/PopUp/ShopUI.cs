using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopUI : UI_PopUp
{

    string _flowerName;
    FlowerBook _flowerBook;
    enum Buttons
    {
        Buy,
        Delete,
    }

    enum Texts
    {
        Branch,
        GoldBranch,
    }
    
    void Start()
    {
        //Init();
    }

    public override void Init()
    {
        base.Init();

        //Object πŸ¿ŒµÂ
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        BindEvent(GetButton((int)Buttons.Delete).gameObject, Btn_Delete);
        BindEvent(GetButton((int)Buttons.Buy).gameObject, Btn_Buy);
    }
    public void SetUI(FlowerBook flowerBook)
    {
        Init();
        _flowerBook = flowerBook;
        System.Type tmpClassType = flowerBook.GetType();
        _flowerName = tmpClassType.Name;

        Debug.Log(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch);

        Debug.Log(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch);

        GetText((int)Texts.Branch).text = $"Branch: {GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch}";
        GetText((int)Texts.GoldBranch).text = $"GoldBranch: {GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch}";
        

    }
    void Btn_Buy(PointerEventData evt)
    {

        if(GameManager.InGameDataManager.Branch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch
            && GameManager.InGameDataManager.GoldBranch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch)
        {
            GameManager.InGameDataManager.Branch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch;
            GameManager.InGameDataManager.GoldBranch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch;
            GameManager.InGameDataManager.saveData();
            _flowerBook.BuyIt();
            ClosePopupUI();
        }

    }

    void Btn_Delete(PointerEventData evt)
    {
        ClosePopupUI();

    }
    

}
