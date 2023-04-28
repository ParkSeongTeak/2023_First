using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


/// <summary>
/// Default Ŭ���� ���� ���Ѵٸ� �巡��, ���� ����, �� ����, �巡����, �巡�� ��, ���� �����ϰ� ���� �� �ִ�.
/// </summary>
public class EventTriggerEX : MonoBehaviour
{
    EventTrigger eventTrigger;
    /// <summary>
    /// ��ư�� �̺�Ʈ Ʈ���Ÿ� �߰��ϰ� �����ϴ� �Լ� 
    /// ���� init()���� �����ϳ�? �ƴϸ� �׳� Start�� ������ �ϳ��� �����ϴ� ����� �����ϱ⸦ �ٶ�.
    /// </summary>
    protected void init()
    {
        transform.AddComponent<EventTrigger>();
        eventTrigger = GetComponent<EventTrigger>();
        
        //Ŭ��
        EventTrigger.Entry entry_Click = new EventTrigger.Entry();
        entry_Click.eventID = EventTriggerType.PointerClick;
        entry_Click.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click);

        /*
        // ���� ����
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

        //�巡�� ��
        EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
        entry_Drag.eventID = EventTriggerType.Drag;
        entry_Drag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Drag);

        //�巡�� ��
        EventTrigger.Entry entry_EndDrag = new EventTrigger.Entry();
        entry_EndDrag.eventID = EventTriggerType.EndDrag;
        entry_EndDrag.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_EndDrag);

        //�巡�� ����
        EventTrigger.Entry entry_BeginDrag = new EventTrigger.Entry();
        entry_BeginDrag.eventID = EventTriggerType.BeginDrag;
        entry_BeginDrag.callback.AddListener((data) => { OnBeginDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_BeginDrag);

        //���� ���� �̷� ����� �ʿ��ϴٸ� Ȯ��
        */

    }
    /// <summary>
    /// ��ư�� ������ �߻��� ���� �־��ִ� �Լ� 
    /// </summary>
    /// <param name="data"></param>
    protected virtual void OnPointerClick(PointerEventData data) { }
    /*
    // ���� ����
    protected virtual void OnPointerDown(PointerEventData data) { }
    //�巡�� ��
    protected virtual void OnDrag(PointerEventData data) { }
    //�巡�� ��
    protected virtual void OnEndDrag(PointerEventData data) { }
    //�巡�� ����
    protected virtual void OnBeginDrag(PointerEventData data) { }
    */
}