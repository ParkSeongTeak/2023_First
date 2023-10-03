using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    int num = 0;

    public int BackGroundIDX;


    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    private void init()
    {
        BackGroundIDX = TileController.Instance.BackGroundIDX;
        TileController.Instance.BackGroundMove += ThisMove;
        TileController.Instance.BackGrounds[num] = this;

        if(TileController.Instance.BackGrounds[0] != null && TileController.Instance.BackGrounds[1] != null)
        {
            TileController.Instance.Distance = TileController.Instance.BackGrounds[1].transform.position - TileController.Instance.BackGrounds[0].transform.position;
        }

    }

    void ThisMove()
    {
        if(transform.position.x < -140)
        {
            transform.position = TileController.Instance.BackGrounds[TileController.Instance.BackGroundIDX].transform.position + TileController.Instance.Distance;
            TileController.Instance.BackGroundIDX = num;
            BackGroundIDX = TileController.Instance.BackGroundIDX;
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
