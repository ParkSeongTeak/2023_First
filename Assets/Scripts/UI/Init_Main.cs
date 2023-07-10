using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.UIManager.ShowSceneUI<MainUI>();
    }


}
