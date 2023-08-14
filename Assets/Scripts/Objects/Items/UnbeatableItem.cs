using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnbeatableItem : Item
{
    public float unbeatableDuration = 10f;

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        Debug.Log("윙윙이랑 충돌");
        if (collision.gameObject.tag == "WingWing")
        {
            //하나의 위치에서 포괄적으로 관리하는게 관리에 더 좋을듯 함 
            //Why? 지금도 아이콘 사라지는 시간, 애니메이션 출력 시간, 슬라이드 멈추는 시간 다 제각각 (지금 당장은10초로 동일할 수 있으나 만약 7초로 바뀐다면?)
            GameUI.Instance.Unbeatable();
            //GameUI.Instance.TimeFreeze();
            //GameManager.InGameDataManager.Player.GetComponent<PlayerController>().Unbeatable();
        }
    }
}


    







