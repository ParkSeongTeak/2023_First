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

        //Object 바인드
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
        

        if(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch != -1 || GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch != -1)
        {
            GetText((int)Texts.Branch).text = $"Branch: {GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch}";
            GetText((int)Texts.GoldBranch).text = $"GoldBranch: {GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch}";
        }
        else
        {
            GetText((int)Texts.Branch).text = "이 상품은 레어상품입니다.";
            GetText((int)Texts.GoldBranch).text = "";

            GetButton((int)Buttons.Buy).gameObject.SetActive(false);
        }


    }
    void Btn_Buy(PointerEventData evt)
    {

        if (GameManager.InGameDataManager.Branch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch 
            && GameManager.InGameDataManager.GoldBranch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch)
        {
            Debug.Log("you can buy it!");
            GameManager.InGameDataManager.Branch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch;
            GameManager.InGameDataManager.GoldBranch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch;
            GameManager.InGameDataManager.saveData();
            _flowerBook.BuyIt();
            ClosePopupUI();
        }
        else
            Debug.Log("you cant buy it...");

    }

    void Btn_Delete(PointerEventData evt)
    {
        ClosePopupUI();

    }
    

}
