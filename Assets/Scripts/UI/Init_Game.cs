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

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y > -9)
            {
                //GetComponent<GameOver>().DisableGameOverMenu()
                
            }
            else 
            {
                Destroy(player);
                GameManager.UIManager.ShowPopupUI<GameOverUI>();
            }
        }

    }

}