using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class State 
{
    #region Quest°ü·Ã Data
    public int QuestNum { get; set; }

    int _jumpCnt = 0;

    public int JumpCnt 
    {
        get { return _jumpCnt; }
        set { _jumpCnt = value;  }
    }
    int _skipCnt = 0;
    public int SkipCnt
    {
        get { return _skipCnt; }
        set { _skipCnt = value;  }
    }
    int _bloomCnt = 0;
    public int BloomCnt
    {
        get { return _bloomCnt; }
        set { _bloomCnt = value; }
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

    List<string> rareTile = new List<string>() { "ÁÖ°Æ´ó°­³ª¹«", "È÷¾î¸®", "²¤²¤ÀÌÇ®", "»êÀÛ¾à", "³Êµµ¹Ù¶÷²É", "±Ý»õ¿ì³­" };

    public int GoldenBranch
    {
        get { return _bloomCnt; }
        set 
        {
            if (_rndNum < 6)
            {
                if (_rndNum == 0)
                {
                    rareTile.RemoveAt(0);
                    UiTexts[(int)Define.Texts.RareTile].text = $"Èñ±ÍÅ¸ÀÏ : ÁÖ°Æ´ó°­³ª¹«";
                }

                else if (_rndNum == 1)
                {
                    rareTile.RemoveAt(1);
                    UiTexts[(int)Define.Texts.RareTile].text = $"Èñ±ÍÅ¸ÀÏ : È÷¾î¸®";
                }

                else if (_rndNum == 2)
                {
                    rareTile.RemoveAt(2);
                    UiTexts[(int)Define.Texts.RareTile].text = $"Èñ±ÍÅ¸ÀÏ : ²¤²¤ÀÌÇ®";
                }

                else if (_rndNum == 3)
                {
                    rareTile.RemoveAt(3);
                    UiTexts[(int)Define.Texts.RareTile].text = $"Èñ±ÍÅ¸ÀÏ : »êÀÛ¾à";
                }

                else if (_rndNum == 4)
                {
                    rareTile.RemoveAt(4);
                    UiTexts[(int)Define.Texts.RareTile].text = $"Èñ±ÍÅ¸ÀÏ : ³Êµµ¹Ù¶÷²É";
                }

                else
                {
                    rareTile.RemoveAt(5);
                    UiTexts[(int)Define.Texts.RareTile].text = $"Èñ±ÍÅ¸ÀÏ : ±Ý»õ¿ì³­";
                }
            }

            else if (_rndNum >= 6 && _rndNum < 14)
            {
                _goldenBranch += 1;
                UiTexts[(int)Define.Texts.GoldenBranch].text = $"È²±Ý³ª¹µ°¡Áö : 1" ;
            }

            else if (_rndNum >= 14 && _rndNum < 18)
            {
                _goldenBranch += 2;
                UiTexts[(int)Define.Texts.GoldenBranch].text = $"È²±Ý³ª¹µ°¡Áö : 2";
            }

            else if (_rndNum >= 18 && _rndNum < 20)
            {
                _goldenBranch += 3;
                UiTexts[(int)Define.Texts.GoldenBranch].text = $"È²±Ý³ª¹µ°¡Áö : 3";
            }
            
            else if (_rndNum >= 20 && _rndNum < 60)
            {
                _branch += 5;
                UiTexts[(int)Define.Texts.Branch].text = $"³ª¹µ°¡Áö : 5";
            }

            else if (_rndNum >= 60 && _rndNum < 80)
            {
                _branch += 10;
                UiTexts[(int)Define.Texts.Branch].text = $"³ª¹µ°¡Áö : 10";
            }

            else if (_rndNum >= 80 && _rndNum < 93)
            {
                _branch += 15;
                UiTexts[(int)Define.Texts.Branch].text = $"³ª¹µ°¡Áö : 15";
            }

            else
            {
                _branch += 20;
                UiTexts[(int)Define.Texts.Branch].text = $"³ª¹µ°¡Áö : 20";
            }
        }
    }
    

    #endregion

    protected QuestHandler _questHandler = new QuestHandler();
    public QuestHandler QuestHandler { get { return _questHandler; } }       //ÀÚ·á±¸Á¶


}
