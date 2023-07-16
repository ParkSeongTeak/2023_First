using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerButton : MonoBehaviour
{

    [SerializeField]
    FlowerBook FlowerUI;

    private void Start()
    {
        
    }

    public FlowerBook GetFlowerUI()
    {
        return FlowerUI;
    }


}
