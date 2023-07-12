using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.InGameDataManager.CreatePlayer();
        GameManager.UIManager.ShowSceneUI<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
