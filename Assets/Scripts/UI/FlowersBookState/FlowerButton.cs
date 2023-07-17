using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerButton : MonoBehaviour
{

    [SerializeField]
    FlowerBook FlowerUI;

    static Color DontHave = new Color(0.5f, 0.5f, 0.5f,1);
    static Color Have = new Color(1, 1, 1, 1);
    static Color Pick = new Color(1, 1, 1, 0.5f);

    private void Start()
    {
        UIUpdate();
        FlowerUI.SetMyFlowerButton(this);

    }
    public void SelectModeDequeue()
    {
        this.gameObject.GetComponent<Image>().color = Have;
    }
    public void UIUpdate()
    {
        System.Type tmpClassType = FlowerUI.GetType();

        if (!FlowerUI.GetHave())
        {
            this.gameObject.GetComponent<Image>().color = DontHave;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = Have;
            
            foreach(Define.FlowerTypes flowerType in FlowersBookUI.GetSelectQueue())
            {
                if(Enum.GetName(typeof(Define.FlowerTypes), flowerType ) == FlowerUI.GetType().Name)
                {
                    this.gameObject.GetComponent<Image>().color = Pick;
                }

            }

        }
    }

    public FlowerBook GetFlowerUI()
    {
        return FlowerUI;
    }
}
