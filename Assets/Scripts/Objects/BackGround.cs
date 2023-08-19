using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    int num = 0;


    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    private void init()
    {
        TileController.Instance.BackGroundMove += ThisMove;
        TileController.Instance.BackGrounds[num] = this;

    }

    void ThisMove()
    {
        if(transform.position.x < -100)
        {
            transform.position = TileController.Instance.BackGrounds[TileController.Instance.BackGroundIDX].transform.position + new Vector3(100.43f,0,0);
            TileController.Instance.BackGroundIDX = num;
            StartCoroutine(TileController.Instance.SmoothMove(transform, transform.position, transform.position - TileController.Instance.DeltaMove));
        }
        else
        {
            StartCoroutine(TileController.Instance.SmoothMove(transform, transform.position, transform.position - TileController.Instance.DeltaMove));

        }
    }

    public void DestroyThisBackground()
    {
        TileController.Instance.BackGroundMove -= ThisMove;
        Destroy(gameObject);
    }


}
