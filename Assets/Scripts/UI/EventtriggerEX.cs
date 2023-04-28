using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


/// <summary>
/// Default 클릭만 지원 원한다면 드래그, 누른 순간, 뗀 순간, 드래그중, 드래그 후, 등을 지원하게 만들 수 있다.
/// </summary>
public class EventTriggerEX : MonoBehaviour
{
    EventTrigger eventTrigger;
    protected void init()
    {
        transform.AddComponent<EventTrigger>();
        eventTrigger = GetComponent<EventTrigger>();
        
        //클릭
        EventTrigger.Entry entry_Click = new EventTrigger.Entry();
        entry_Click.eventID = EventTriggerType.PointerClick;
        entry_Click.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click);

        /*
        // 누른 순간
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

        //드래그 중
        EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
        entry_Drag.eventID = EventTriggerType.Drag;
        entry_Drag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Drag);

        //드래그 끝
        EventTrigger.Entry entry_EndDrag = new EventTrigger.Entry();
        entry_EndDrag.eventID = EventTriggerType.EndDrag;
        entry_EndDrag.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_EndDrag);

        //드래그 시작
        EventTrigger.Entry entry_BeginDrag = new EventTrigger.Entry();
        entry_BeginDrag.eventID = EventTriggerType.BeginDrag;
        entry_BeginDrag.callback.AddListener((data) => { OnBeginDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_BeginDrag);

        //등등등 뭔가 이런 기능이 필요하다면 확장
        */

    }

    protected virtual void OnPointerClick(PointerEventData data) { }
    /*
    // 누른 순간
    protected virtual void OnPointerDown(PointerEventData data) { }
    //드래그 중
    protected virtual void OnDrag(PointerEventData data) { }
    //드래그 끝
    protected virtual void OnEndDrag(PointerEventData data) { }
    //드래그 시작
    protected virtual void OnBeginDrag(PointerEventData data) { }
    */
}