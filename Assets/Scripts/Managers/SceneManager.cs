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
        GameManager.UIManager.CloseAllPopupUI();
        Application.LoadLevel(Enum.GetName(typeof(Define.Scenes), scene));

    }

    public void Clear()
    {

    }
}
