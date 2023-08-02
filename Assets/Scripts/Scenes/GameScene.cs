using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.InGameDataManager.NowState.GameDataClear();
        TileController.init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
