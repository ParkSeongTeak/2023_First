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
        FlowerIcon,

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

        //Object ���ε�
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

        Debug.Log(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch);

        Debug.Log(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch);
        


        if(GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch != -1 || GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch != -1)
        {
            GetText((int)Texts.KoreanName).text = $"{KoreanName}";
            GetText((int)Texts.Branch).text = $"{GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch}";
            GetText((int)Texts.GoldBranch).text = $"{GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch}";
            GetImage((int)Images.Flower).sprite = FlowerIcon;


        }
        else
        {
            GetText((int)Texts.KoreanName).text = $"{KoreanName}";
            GetText((int)Texts.Branch).text = "X";
            GetText((int)Texts.GoldBranch).text = "X";
            GetImage((int)Images.Flower).sprite = FlowerIcon;

            GetButton((int)Buttons.Buy).gameObject.SetActive(false);

            //���� ����
        }


    }
    void Btn_Buy(PointerEventData evt)
    {

        if (GameManager.InGameDataManager.Branch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch 
            && GameManager.InGameDataManager.GoldBranch >= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch)
        {
            Debug.Log("you can buy it!");
            GameManager.SoundManager.Play(Define.SFX.congrats02_03);//congrats02_03ȿ����
            GameManager.InGameDataManager.Branch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].Branch;
            GameManager.InGameDataManager.GoldBranch -= GameManager.InGameDataManager.FlowerPriceHandler[_flowerName].GoldBranch;
            GameManager.InGameDataManager.saveData();
            _flowerBook.BuyIt();
            ClosePopupUI();
        }
        else
            GameManager.SoundManager.Play(Define.SFX.Error_01);//Error_01ȿ����
            Debug.Log("you cant buy it...");

    }

    void Btn_Delete(PointerEventData evt)
    {
        GameManager.SoundManager.Play(Define.SFX.click_01);//click_01ȿ����
        ClosePopupUI();

    }
    

}
