using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;
using static Define;

public class FlowersBookUI : UI_Scene
{

    static Queue<FlowerTypes> _selectQueue = new Queue<FlowerTypes>();

    public static Queue<FlowerTypes> GetSelectQueue()
    {
        return _selectQueue;
    }
    public static bool EnqueueSelectQueue(FlowerTypes input)
    {
        foreach (FlowerTypes flowerType in _selectQueue)
        {
            if (flowerType == input)
            {
                return false;
            }
        }
        _selectQueue.Enqueue(input);
        DequeueSelectQueue();

        Debug.Log($"_selectQueue.Count {_selectQueue.Count} ");
        return true;
    }
    public static void DequeueSelectQueue()
    {
        FlowerTypes dequeue = _selectQueue.Dequeue();
        FlowerButton[] flowerButtons = FindObjectsOfType<FlowerButton>();
        Debug.Log(flowerButtons.Length);

        foreach (FlowerButton fb in flowerButtons)
        {
            if (fb.GetFlowerUI().GetType().Name == Enum.GetName(typeof(FlowerTypes), dequeue)) 
            {
                fb.SelectModeDequeue();
                break;
            }
        }
    }
    enum Buttons
    {
        Select,
        Save,
        Back,
        Reset,

    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        //Object 바인드
        Bind<Button>(typeof(Buttons));

        //Btn에 이벤트 연결
        BindEvent(GetButton((int)Buttons.Select).gameObject, Btn_Select);
        BindEvent(GetButton((int)Buttons.Save).gameObject, Btn_Save);
        BindEvent(GetButton((int)Buttons.Back).gameObject, Btn_Back);
        BindEvent(GetButton((int)Buttons.Reset).gameObject, Btn_Reset);

        _selectQueue.Clear();
        foreach (FlowerTypes flower in GameManager.InGameDataManager.UseFlowerList)
        {
            _selectQueue.Enqueue(flower);
        }
        Debug.Log($"_selectQueue.Count {_selectQueue.Count} ");
    }

    #region Button Event

    void Btn_Select(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState = GameManager.InGameDataManager.bookSelect;
    }
    void Btn_Save(PointerEventData evt)
    {
        if (_selectQueue.Count == 3) {
            int idx = 0;
            foreach (FlowerTypes flowerType in _selectQueue)
            {
                GameManager.InGameDataManager.UseFlowerList[idx++] = flowerType;
            }
            GameManager.InGameDataManager.saveData();
        }
        else
        {
            Debug.Log($"selectQueue Count Error {_selectQueue.Count}");
        }
        GameManager.InGameDataManager.bookState = GameManager.InGameDataManager.bookInfo;

    }
    void Btn_Back(PointerEventData evt)
    {
        GameManager.InGameDataManager.bookState = GameManager.InGameDataManager.bookInfo;
        GameManager.SceneManager.LoadScene(Define.Scenes.Main);

    }


    void Btn_Reset(PointerEventData evt)
    {
        for(FlowerTypes Flower = 0; Flower < FlowerTypes.MaxCount; Flower++)
        {
            PlayerPrefs.SetInt($"{Enum.GetName(typeof(FlowerTypes),Flower)}Have", 0);
        }
        PlayerPrefs.SetInt("Branch", 500);
        PlayerPrefs.SetInt("GoldBranch", 40);
        PlayerPrefs.SetInt("MaxPoint", 360);
        PlayerPrefs.SetInt("UseFlowerList[0]", (int)FlowerTypes.icon_magnolia1);
        PlayerPrefs.SetInt("UseFlowerList[1]", (int)FlowerTypes.icon_magnolia2);
        PlayerPrefs.SetInt("UseFlowerList[2]", (int)FlowerTypes.icon_magnolia3);
        PlayerPrefs.SetInt("QUESTINDEX", 1);


    }
    #endregion

}
