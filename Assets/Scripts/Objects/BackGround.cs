using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    private void init()
    {
        Debug.Log("Init");
        TileController.Instance.BackGroundMove += ThisMove;

    }

    void ThisMove()
    {
        StartCoroutine(TileController.Instance.SmoothMove(transform, transform.position, transform.position - TileController.Instance.DeltaMove));

    }

    public void DestroyThisBackground()
    {
        TileController.Instance.BackGroundMove -= ThisMove;
        Destroy(gameObject);
    }


}
