using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;
/// <summary>
/// UI는...... 좀 나중에 빡세게 잡고 해야 하나 대충이래도 되나 고민 중입니다.
/// </summary>
public class UIManager
{
    #region UI
    GameObject[] _uibuttons;
    TextMeshProUGUI[] _uiTexts;
    Image[] _uiImages;
    GameObject[] _popUpUI;

    #endregion
    public GameObject[] UiButtons { get { return _uibuttons; } }
    public TextMeshProUGUI[] UiTexts { get { return _uiTexts; } }
    public Image[] UiImages { get { return _uiImages; } }

    public GameObject[] PopUpUI { get{ return _popUpUI; } }

    public void init()
    {

        _uibuttons = new GameObject[(int)Define.Buttons.MaxCount];
        string[] _uibuttonsstr = Enum.GetNames(typeof(Define.Buttons));

        for (int i = 0; i < (int)Define.Buttons.MaxCount; i++)
        {
            _uibuttons[i] = GameObject.Find(_uibuttonsstr[i]);
        }

        _uiTexts = new TextMeshProUGUI[(int)Define.Texts.MaxCount];
        string[] _textButtonsstr = Enum.GetNames(typeof(Define.Texts));
        for (int i = 0; i < (int)Define.Texts.MaxCount; i++)
        {
            _uiTexts[i] = GameObject.Find(_textButtonsstr[i]).GetComponent<TextMeshProUGUI>();
        }

        _uiImages = new Image[(int)Define.Images.MaxCount];
        string[] _ImagesFieldsstr = Enum.GetNames(typeof(Define.Images));
        for (int i = 0; i < (int)Define.Images.MaxCount; i++)
        {
            _uiImages[i] = GameObject.Find(_ImagesFieldsstr[i]).GetComponent<Image>();
        }


        _popUpUI = new GameObject[(int)Define.PopUpUI.MaxCount];
        string[] _popUpUIstr = Enum.GetNames(typeof(Define.PopUpUI));
        for (int i = 0; i < (int)Define.PopUpUI.MaxCount; i++)
        {
            _popUpUI[i] = GameObject.Find(_popUpUIstr[i]).GetComponent<GameObject>();
        }


        //UI는 어떻게 바꿔야 하나? 이미지면 이미지 접근 후 내가 원하는 이미지를 UiImages[(int)Define.Images.원하는 이미지]로 접근 
        GameManager.UIManager.UiImages[(int)Define.Images.flowerImg].sprite = GameManager.ResourceManager.Load<Sprite>("Sprites/img");
        //Text는 ?
        GameManager.UIManager.UiTexts[(int)Define.Texts.ScoreTxt].text = "How To Use UI?";
        //UIUpdate();

    }
    public void Clear()
    {

    }

    public void UIUpdate()
    {
        //UiTexts[(int)Define.Texts.JumpCnt].text = GameManager.InGameDataManager.JumpCnt.ToString();
        if (GameManager.InGameDataManager.NormalQuestHandler[1].Jump > GameManager.InGameDataManager.JumpCnt)
        {
            UiTexts[(int)Define.Texts.JumpCnt].text = $"JumpCnt : {GameManager.InGameDataManager.NormalQuestHandler[1].Jump - GameManager.InGameDataManager.JumpCnt}";
            //UiTexts[(int)Define.Texts.JumpCnt].text = $"JumpCnt : {4 - GameManager.InGameDataManager.JumpCnt}";
        }
        if (GameManager.InGameDataManager.NormalQuestHandler[1].Jump <= GameManager.InGameDataManager.JumpCnt)
        {
            UiTexts[(int)Define.Texts.JumpCnt].text = $"JumpCnt : Clear!";
        }

        if (GameManager.InGameDataManager.NormalQuestHandler[1].Skip > GameManager.InGameDataManager.SkipCnt)
        {
            UiTexts[(int)Define.Texts.SkipCnt].text = $"SkipCnt : {GameManager.InGameDataManager.NormalQuestHandler[1].Skip - GameManager.InGameDataManager.SkipCnt}";
        }
        if (GameManager.InGameDataManager.NormalQuestHandler[1].Skip <= GameManager.InGameDataManager.SkipCnt)
        {
            UiTexts[(int)Define.Texts.SkipCnt].text = $"SkipCnt : Clear!";
        }
        if (GameManager.InGameDataManager.NormalQuestHandler[1].Bloom > GameManager.InGameDataManager.BloomCnt)
        {
            UiTexts[(int)Define.Texts.BloomCnt].text = $"BloomCnt : {GameManager.InGameDataManager.NormalQuestHandler[1].Bloom - GameManager.InGameDataManager.BloomCnt}";
        }
        if (GameManager.InGameDataManager.NormalQuestHandler[1].Bloom <= GameManager.InGameDataManager.BloomCnt)
        {
            UiTexts[(int)Define.Texts.BloomCnt].text = $"BloomCnt : Clear!";
        }



        UiTexts[(int)Define.Texts.JumpScore].text = $"Jump Score : {GameManager.InGameDataManager.JumpCnt}";
        UiTexts[(int)Define.Texts.SkipScore].text = $"Skip Score : {GameManager.InGameDataManager.SkipCnt}";
        UiTexts[(int)Define.Texts.BloomScore].text = $"Bloom Score : {GameManager.InGameDataManager.BloomCnt}";

    }

    int tmptmp()
    {
        int tmptmpttmp = GameManager.InGameDataManager.NormalQuestHandler[1].Jump - GameManager.InGameDataManager.JumpCnt;
        
        return tmptmpttmp;
    }

}
