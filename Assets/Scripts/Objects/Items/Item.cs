using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class Item : MonoBehaviour
{
    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WingWing")
        {
           Destroy(gameObject);
        }
    }

}
