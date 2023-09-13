using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

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
        Warning,

    }

    enum Images
    {
        Flower,
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
        Bind<Image>(typeof(Images));

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
        Sprite FlowerIcon = flowerBook.FlowerIcon;

        
        if(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch != -1 || GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch != -1)
        {
            GetText((int)Texts.KoreanName).text = $"{KoreanName}";
            GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch}";
            GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch}";
            GetImage((int)Images.Flower).sprite = FlowerIcon;

            GameObject _warning = GameObject.Find("Warning");
            _warning.SetActive(false);


        }
        else
        {
            GetText((int)Texts.KoreanName).gameObject.SetActive(false);
            GetText((int)Texts.Branch).gameObject.SetActive(false);
            GetText((int)Texts.GoldBranch).gameObject.SetActive(false);
            GetImage((int)Images.Flower).gameObject.SetActive(false);
            GetButton((int)Buttons.Buy).gameObject.SetActive(false);

            GameObject _branchIcon = GameObject.Find("Branch_icon");
            GameObject _goldenbranchIcon = GameObject.Find("GoldenBranch_icon");

            _branchIcon.SetActive(false);
            _goldenbranchIcon.SetActive(false);

            
        }


    }
    void Btn_Buy(PointerEventData evt)
    {

        if (GameManager.InGameDataManager.Branch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch 
            && GameManager.InGameDataManager.GoldBranch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch)
        {
            GameManager.SoundManager.Play(Define.SFX.congrats02_03);//congrats02_03효과음
            GameManager.InGameDataManager.Branch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch;
            GameManager.InGameDataManager.GoldBranch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch;
            GameManager.InGameDataManager.saveData();
            _flowerBook.BuyIt();
            ClosePopupUI();
        }
        else
            GameManager.SoundManager.Play(Define.SFX.Error_01);//Error_01효과음  //에러 사운드
        
    }

    void Btn_Delete(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_02);//click_02효과음
        ClosePopupUI();

    }
    

}
