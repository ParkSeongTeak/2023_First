using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_FlowersBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.UIManager.ShowSceneUI<FlowersBookUI>();
        GameManager.UIManager.ShowPopupUI<Page1>();
    }

    
}
