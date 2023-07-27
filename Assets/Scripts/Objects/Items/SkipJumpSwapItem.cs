using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipJumpSwapItem : MonoBehaviour
{  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WingWing") 
        {
            GameUI.Instance.SkipJumpSwapItem();
            Destroy(gameObject);
        }
    }

}


