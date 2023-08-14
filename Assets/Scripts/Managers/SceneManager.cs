using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager 
{
    public void init()
    {

    }

    public void LoadScene(Define.Scenes scene)
    {
        Application.LoadLevel(Enum.GetName(typeof(Define.Scenes), scene));
        GameManager.UIManager.CloseAllPopupUI();

    }

    public void Clear()
    {

    }
}
