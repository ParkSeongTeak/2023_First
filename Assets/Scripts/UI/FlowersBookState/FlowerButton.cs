using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerButton : MonoBehaviour
{

    [SerializeField]
    FlowerBook FlowerUI;

    int _have = 0;


    public int HaveIt()
    {
        return _have;
    }

    public void BuyIt()
    {
        _have = 1;

        System.Type tmpClassType = FlowerUI.GetType();
        PlayerPrefs.SetInt(tmpClassType.Name, 1);
    }

    private void Start()
    {
        System.Type tmpClassType = FlowerUI.GetType();
        _have = PlayerPrefs.GetInt(tmpClassType.Name, 0);

        //FlowerUI.ShowPrice();


    }

    public FlowerBook GetFlowerUI()
    {
        return FlowerUI;
    }


}
