using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnbeatableItem : Item
{
    public float unbeatableDuration = 10f;
    private bool isUnbeatable;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�����̶� �浹");
        if (collision.gameObject.tag == "WingWing")

        {
            GameUI.Instance.Unbeatable();
           

            Destroy(gameObject); //������ ������Ʈ�� ����


        }
    }
}


    







