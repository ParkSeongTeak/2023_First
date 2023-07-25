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

    void Start()
    {
        icon = Instantiate(Icon);
        icon.SetActive(false);
    }
    

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "WingWing")
        {
            if (GameManager.InGameDataManager.NowState.LifeCnt == 1)    //��� ����Ʈ 1�� �����϶��� ��� �߰� ȹ�� ����
            {
                GameManager.InGameDataManager.NowState.LifeCnt++;
                icon.SetActive(true);
            }
            
        }

    }

}