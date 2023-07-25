using System.Collections;
using UnityEngine;

public class UnbeatableItem : Item
{
    public float unbeatableDuration = 10f;
    private bool isUnbeatable = false;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "WingWing")
        {
            if (!isUnbeatable)
            {
                Unbeatable();
            }
        }
    }

    private void Unbeatable()
    {
        isUnbeatable = true;
        StartCoroutine(ResumeUnbeatableAfterDelay(unbeatableDuration));
    }

    private IEnumerator ResumeUnbeatableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isUnbeatable = false;
    }
}

