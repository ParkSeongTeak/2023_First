using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTile : Tile
{
    public Define.LeafTypes MyLeafType { get; set; }
    //public GameObject[] prefabs { get; set; }
    private Vector3 itemPosition;
    GameObject ItemOnMe;
    private bool itemworked;
    private int jumpnum;
    private int flowernum;

    public override void Init()
    {
        MyLeafType = TileController.Instance.SetLeafType();
        transform.GetComponent<SpriteRenderer>().sprite = TileController.Instance.LeafSprites[(int)MyLeafType];
        
    }

    

    void OnEnable()
    {
        itemPosition = transform.position;
        float probability = 0.28f;
        itemworked = false;

        if (UnityEngine.Random.value < probability)
        {
            Define.Items randomItem = (Define.Items)UnityEngine.Random.Range(0, (int)Define.Items.MaxCount);

            ItemOnMe = GetPrefabByItem(randomItem);

            if (ItemOnMe == null)
            {
                Debug.LogError("Prefab not found for item: " + randomItem);
            }
            itemPosition.y += 2.2f;
            itemPosition.z -= 0.1f;
            GameObject spawnedPrefab = Instantiate(ItemOnMe, itemPosition, Quaternion.identity);
            spawnedPrefab.transform.parent = transform;
        }
    }

    private GameObject GetPrefabByItem(Define.Items item)
    {
        if (ItemOnMe == null)
        {
            string prefabPath = "Prefabs/ItemTypes/" + item.ToString();
            ItemOnMe = GameManager.ResourceManager.Load<GameObject>(prefabPath);
        }
        return ItemOnMe;

    }

    public override void JumpOnMe()
    {
        
    }
    public override void SkipOnMe()
    {

    }
    public override void ChangeFlower(int leafposition)
    {
        
        int idx = TileController.Instance.NowGeneratedTiles.IndexOf(this);

        TileController.Instance.LeafToFlower(idx);

    }
}
