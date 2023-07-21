using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTile : Tile
{
    public Define.LeafTypes MyLeafType { get; set; }
    public GameObject[] prefabs;
    private Vector3 itemPosition;
    private bool itemworked;
    private int jumpnum;
    private int flowernum;

    public override void Init()
    {
        MyLeafType = TileController.Instance.SetLeafType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.LeafSprites[(int)MyLeafType];
        itemPosition = transform.position;
    }

    void Start()
    {
        float probability = 0.2f;
        itemworked = false;

        //if (UnityEngine.Random.value < probability)
        {
            Define.Items randomItem = (Define.Items)UnityEngine.Random.Range(0, (int)Define.Items.MaxCount);

            GameObject prefab = GetPrefabByItem(randomItem);

            if (prefab == null)
            {
                Debug.LogError("Prefab not found for item: " + randomItem);
            }
            itemPosition.y += 2.2f;

            GameObject spawnedPrefab = Instantiate(prefab, itemPosition, Quaternion.identity);
            spawnedPrefab.transform.parent = transform;
        }
    }

    private GameObject GetPrefabByItem(Define.Items item)
    {
        string prefabPath = "Prefabs/ItemTypes/" + item.ToString();
        GameObject prefab = Resources.Load<GameObject>(prefabPath);
        return prefab;
    }

    public override void JumpOnMe()
    {
        if (!itemworked)
        {
            GameManager.InGameDataManager.NowState.JumpCnt--;
        }
        else
        {
            if (jumpnum >= 0)
            {
                jumpnum--;
                if (jumpnum > -1)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[jumpnum];
                }
                if (jumpnum == -1)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.FlowerSprites[flowernum];
                    GameManager.InGameDataManager.NowState.BloomCnt++;
                }
            }
            else
            {
                GameManager.GameOver(2f);
                Destroy(gameObject);
                itemworked = false;
            }
        }
    }
    public override void SkipOnMe()
    {

    }
    public override void ChangeFlower(int leafposition)
    {
        itemworked = true;
        base.ChangeFlower(leafposition);
        flowernum = UnityEngine.Random.RandomRange(0,2);
        jumpnum = UnityEngine.Random.RandomRange(1,3);
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.CosmosFlowerSprites[(int)jumpnum];

    }
}
