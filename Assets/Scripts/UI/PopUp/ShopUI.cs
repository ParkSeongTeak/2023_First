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

        KoreanName,
        Branch,
        GoldBranch,
        FlowerName,
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
        string KoreanName = flowerBook.KoreanFlowerName;

        Debug.Log(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch);

        Debug.Log(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch);
        

        if(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch != -1 || GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch != -1)
        {
            GetText((int)Texts.KoreanName).text = $"{KoreanName}";

            GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch}";
            GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch}";
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
            GameManager.SoundManager.Play(Define.SFX.congrats02_03);//congrats02_03효과음
            GameManager.InGameDataManager.Branch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch;
            GameManager.InGameDataManager.GoldBranch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch;
            GameManager.InGameDataManager.saveData();
            _flowerBook.BuyIt();
            ClosePopupUI();
        }
        else
            GameManager.SoundManager.Play(Define.SFX.Error_01);//Error_01효과음
            Debug.Log("you cant buy it...");

    }

    void Btn_Delete(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_01);//click_01효과음
        ClosePopupUI();

    }
    

}
