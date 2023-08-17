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
        set { 
            _bloomCnt = value;
            if (_bloomCnt > GameManager.InGameDataManager.MaxPoint) { GameManager.InGameDataManager.MaxPoint = _bloomCnt; }
        }
    }
    public const float Reward_Bloom_Weight = 0.2f;

    int _branch = 0;
    public int Branch
    {

        get { _branch = Mathf.RoundToInt(BloomCnt * 0.2f); return _branch; }  
        set { _branch = value; }

    }
    int _lifeCnt = 1;
    public int LifeCnt
    {
        get { return _lifeCnt; }
        set { _lifeCnt = value; }
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

    List<string> rareTile = new List<string>() { "주걱댕강나무", "히어리", "깽깽이풀", "산작약", "너도바람꽃", "금새우난" };

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
                    UiTexts[(int)Define.Texts.RareTile].text = $"희귀타일 : 주걱댕강나무";
                }

                else if (_rndNum == 1)
                {
                    rareTile.RemoveAt(1);
                    UiTexts[(int)Define.Texts.RareTile].text = $"희귀타일 : 히어리";
                }

                else if (_rndNum == 2)
                {
                    rareTile.RemoveAt(2);
                    UiTexts[(int)Define.Texts.RareTile].text = $"희귀타일 : 깽깽이풀";
                }

                else if (_rndNum == 3)
                {
                    rareTile.RemoveAt(3);
                    UiTexts[(int)Define.Texts.RareTile].text = $"희귀타일 : 산작약";
                }

                else if (_rndNum == 4)
                {
                    rareTile.RemoveAt(4);
                    UiTexts[(int)Define.Texts.RareTile].text = $"희귀타일 : 너도바람꽃";
                }

                else
                {
                    rareTile.RemoveAt(5);
                    UiTexts[(int)Define.Texts.RareTile].text = $"희귀타일 : 금새우난";
                }
            }

            else if (_rndNum >= 6 && _rndNum < 14)
            {
                _goldenBranch += 1;
                UiTexts[(int)Define.Texts.GoldenBranch].text = $"황금나뭇가지 : 1" ;
            }

            else if (_rndNum >= 14 && _rndNum < 18)
            {
                _goldenBranch += 2;
                UiTexts[(int)Define.Texts.GoldenBranch].text = $"황금나뭇가지 : 2";
            }

            else if (_rndNum >= 18 && _rndNum < 20)
            {
                _goldenBranch += 3;
                UiTexts[(int)Define.Texts.GoldenBranch].text = $"황금나뭇가지 : 3";
            }
            
            else if (_rndNum >= 20 && _rndNum < 60)
            {
                _branch += 5;
                UiTexts[(int)Define.Texts.Branch].text = $"나뭇가지 : 5";
            }

            else if (_rndNum >= 60 && _rndNum < 80)
            {
                _branch += 10;
                UiTexts[(int)Define.Texts.Branch].text = $"나뭇가지 : 10";
            }

            else if (_rndNum >= 80 && _rndNum < 93)
            {
                _branch += 15;
                UiTexts[(int)Define.Texts.Branch].text = $"나뭇가지 : 15";
            }

            else
            {
                _branch += 20;
                UiTexts[(int)Define.Texts.Branch].text = $"나뭇가지 : 20";
            }
        }
    }
    

    #endregion

    protected QuestHandler _questHandler = new QuestHandler();
    public QuestHandler QuestHandler { get { return _questHandler; } }       //자료구조


    public void GameDataClear()
    {
        JumpCnt = 0;
        SkipCnt = 0;
        BloomCnt = 0;
    }

}
