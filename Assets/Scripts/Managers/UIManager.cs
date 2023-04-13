using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;
/// <summary>
/// UI��...... �� ���߿� ������ ��� �ؾ� �ϳ� �����̷��� �ǳ� ��� ���Դϴ�.
/// </summary>
public class UIManager 
{
    #region UI
    GameObject[] _uibuttons;
    TextMeshProUGUI[] _uiTexts;
    Image[] _uiImages;
    #endregion
    public GameObject[] UiButtons { get { return _uibuttons; } }
    public TextMeshProUGUI[] UiTexts { get { return _uiTexts; } }
    public Image[] UiImages { get { return _uiImages; } }
    
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

        //UI�� ��� �ٲ�� �ϳ�? �̹����� �̹��� ���� �� ���� ���ϴ� �̹����� UiImages[(int)Define.Images.���ϴ� �̹���]�� ���� 
        GameManager.UIManager.UiImages[(int)Define.Images.flowerImg].sprite = GameManager.ResourceManager.Load<Sprite>("Sprites/img");
        //Text�� ?
        GameManager.UIManager.UiTexts[(int)Define.Texts.ScoreTxt].text = "How To Use UI?";

    }
    public void Clear()
    {

    }
}
