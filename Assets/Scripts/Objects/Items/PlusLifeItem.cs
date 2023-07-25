using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class PlusLifeItem : Item
{

    public GameObject Icon;
    GameObject icon;
    static GameUI gameUI;

    void Start()
    {
        //icon = Instantiate(Icon);
        if(gameUI == null)
        {
            gameUI = GameManager.UIManager.ShowSceneUI<GameUI>();
        }
        if (gameUI.LifeIcon == null)
        {
            gameUI.LifeIcon = Instantiate(Icon);
        }
        gameUI.LifeIcon.SetActive(false);
        //gameUI.LifeIcon = icon;




    }
    

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "WingWing")
        {
            if (GameManager.InGameDataManager.NowState.LifeCnt == 1)    //¸ñ¼û µðÆúÆ® 1°³ »óÅÂÀÏ¶§¸¸ ¸ñ¼û Ãß°¡ È¹µæ °¡´É
            {
                GameManager.InGameDataManager.NowState.LifeCnt++ ;
                gameUI.LifeIcon.SetActive(true);
            }
            
        }

    }

}