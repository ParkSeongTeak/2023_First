using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnbeatableItem : Item
{
    public float unbeatableDuration = 10f;

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        Debug.Log("�����̶� �浹");
        if (collision.gameObject.tag == "WingWing")
        {
            //�ϳ��� ��ġ���� ���������� �����ϴ°� ������ �� ������ �� 
            //Why? ���ݵ� ������ ������� �ð�, �ִϸ��̼� ��� �ð�, �����̵� ���ߴ� �ð� �� ������ (���� ������10�ʷ� ������ �� ������ ���� 7�ʷ� �ٲ�ٸ�?)
            GameUI.Instance.Unbeatable();
            //GameUI.Instance.TimeFreeze();
            //GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Unbeatable();
        }
    }
}


    







