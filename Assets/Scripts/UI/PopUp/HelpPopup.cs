using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HelpPopup : UI_PopUp
{
     enum Images
     {
        Image0, Image1, Image2, Image3, Image4, Image5, Image6, Image7
    }
    enum Buttons
    {
       Next,
    }
    // Start is called before the first frame update
    void Start()
    {
        base.Init();

        //Object πŸ¿ŒµÂ
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));


        for(int i = 1; i < 8; i++)
        {

            GetImage(i).gameObject.SetActive(false);
        }
        BindEvent(GetButton((int)Buttons.Next).gameObject, NextBtn);

    }

    int idx = 1;
    void NextBtn(PointerEventData evt)
    {
        if(idx  == 8)
        {
            GameManager.UIManager.ClosePopupUI();
        }
        else
        {

            GetImage(idx).gameObject.SetActive(true);
            idx++;
        }

    }
    
}
