using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerBackground : MonoBehaviour
{

    [SerializeField]
    FlowerBook FlowerUI;

    static Color DontHave = new Color(0.5f, 0.5f, 0.5f, 1);
    static Color Have = new Color(1, 1, 1, 1);
    static Color Pick = new Color(1, 1, 1, 0.5f);

    private void Start()
    {
        UIUpdate();
    }
    public void SelectModeDequeue()
    {
        this.gameObject.GetComponent<Image>().color = Have;
    }
    public void UIUpdate()
    {

        if (!FlowerUI.GetHave())    //flower doesnt selected
        {
            this.gameObject.GetComponent<Image>().color = DontHave;
        }
        else //flower is selected
        {
            this.gameObject.GetComponent<Image>().color = Have;

            foreach (Define.FlowerTypes flowerType in FlowersBookUI.GetSelectQueue())
            {
                if (Enum.GetName(typeof(Define.FlowerTypes), flowerType) == FlowerUI.GetType().Name)
                {
                    this.gameObject.GetComponent<Image>().color = Pick;
                }

            }

        }
    }

  
}
