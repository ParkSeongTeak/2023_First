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
        //gameUI.LifeIcon.SetActive(false);

        //소리 코드 

        //gameUI.LifeIcon = icon;




    }
    

    public override void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "WingWing")
        {
            GameUI.Instance.PlusLifeItem();        
        }
        base.OnTriggerStay2D(collision);


    }

}