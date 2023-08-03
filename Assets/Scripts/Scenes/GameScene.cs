using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameManager.InGameDataManager.CreatePlayer();
        
        TileController.init();

        GameManager.InGameDataManager.NowState.GameDataClear();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
