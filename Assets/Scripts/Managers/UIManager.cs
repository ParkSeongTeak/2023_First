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

    
    public void Clear()
    {

    }

    
    int _order = 10;

    Stack<UI_PopUp> _popupStack = new Stack<UI_PopUp>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("UI_Root");
            if (root == null)
                root = new GameObject { name = "UI_Root" };
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = GameManager.ResourceManager.Instantiate($"UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        /*
        GameObject go = GameManager.ResourceManager.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
        */
        T sceneUI = Util.FindChild<T>(Root, name);
        if (sceneUI == null)
        {
            GameObject go = GameManager.ResourceManager.Instantiate($"UI/Scene/{name}");
            sceneUI = Util.GetOrAddComponent<T>(go);
            _sceneUI = sceneUI;

            go.transform.SetParent(Root.transform);

            
        }
        return sceneUI;

    }

    public T ShowPopupUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = GameManager.ResourceManager.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    public void ClosePopupUI(UI_PopUp popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_PopUp popup = _popupStack.Pop();
        GameManager.ResourceManager.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

}
