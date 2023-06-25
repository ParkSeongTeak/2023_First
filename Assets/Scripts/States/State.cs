using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class State 
{
    #region Quest관련 Data
    public int QuestNum { get; set; }

    int _jumpCnt = 0;

    public int JumpCnt 
    {
        get { return _jumpCnt; }
        set { _jumpCnt = value; GameManager.UIManager.UIUpdate(QuestNum); }
    }
    int _skipCnt = 0;
    public int SkipCnt
    {
        get { return _skipCnt; }
        set { _skipCnt = value; GameManager.UIManager.UIUpdate(QuestNum); }
    }
    int _bloomCnt = 0;
    public int BloomCnt
    {
        get { return _bloomCnt; }
        set { _bloomCnt = value; GameManager.UIManager.UIUpdate(QuestNum); }
    }
    int _branch = 0;
    public int Branch
    {

        get { _branch = Mathf.RoundToInt(BloomCnt * 0.2f); return _branch; }  
        set { _branch = value; }

    }


    TextMeshProUGUI[] _uiTexts;
    public TextMeshProUGUI[] UiTexts { get { return _uiTexts; } }
    public void init()
    {
        _uiTexts = new TextMeshProUGUI[(int)Define.Texts.MaxCount];
        string[] _textButtonsstr = Enum.GetNames(typeof(Define.Texts));
        for (int i = 0; i < (int)Define.Texts.MaxCount; i++)
        {
            _uiTexts[i] = GameObject.Find(_textButtonsstr[i]).GetComponent<TextMeshProUGUI>();
        }

    }

    int _rndNum = UnityEngine.Random.Range(0, 100);
    int _goldenBranch = 0;
    public int GoldenBranch
    {

        get => _goldenBranch;
        set 
        {
            if (_rndNum < 6)
            {
                if (_rndNum == 0)
                {
                   
                }

                else if (_rndNum == 1)
                {

                }

                else if (_rndNum == 2)
                {

                }

                else if (_rndNum == 3)
                {

                }

                else if (_rndNum == 4)
                {

                }

                else
                {

                }
            }

            else if (_rndNum >= 6 && _rndNum < 14)
            {
                _goldenBranch += 1;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"황금나뭇가지 : 1" ;
            }

            else if (_rndNum >= 14 && _rndNum < 18)
            {
                _goldenBranch += 2;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"황금나뭇가지 : 2";
            }

            else if (_rndNum >= 18 && _rndNum < 20)
            {
                _goldenBranch += 3;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"황금나뭇가지 : 3";
            }
            
            else if (_rndNum >= 20 && _rndNum < 60)
            {
                _branch += 5;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"나뭇가지 : 5";
            }

            else if (_rndNum >= 60 && _rndNum < 80)
            {
                _branch += 10;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"나뭇가지 : 10";
            }

            else if (_rndNum >= 80 && _rndNum < 93)
            {
                _branch += 15;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"나뭇가지 : 15";
            }

            else
            {
                _branch += 20;
                UiTexts[(int)Define.Texts.RndRwrd].text = $"나뭇가지 : 20";
            }
        }
    }
    

    #endregion

    protected QuestHandler _questHandler = new QuestHandler();
    public QuestHandler QuestHandler { get { return _questHandler; } }       //자료구조


}
