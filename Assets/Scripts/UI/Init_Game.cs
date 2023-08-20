using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class Init_Game : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.InGameDataManager.CreatePlayer();
        GameManager.UIManager.ShowSceneUI<GameUI>();
        player = GameObject.FindWithTag("WingWing");

    }

    GameObject restartTile;
    bool gameOver = false;  
    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (player.transform.position.y > -9)
            {
                //GetComponent<GameOver>().DisableGameOverMenu()
                
            }
            else 
            {
                gameOver = true;
                //Destroy(player);
                GameManager.UIManager.ShowPopupUI<GameOverUI>();
            }
        }

    }

}