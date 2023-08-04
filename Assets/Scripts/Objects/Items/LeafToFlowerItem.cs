using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafToFlowerItem : Item
{
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        //LeafToFlower();
        if (collision.gameObject.tag == "WingWing")
        {
            LeafToFlower();
        }
    }

    private void LeafToFlower()
    {
        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;

            for (int i = 3; i <= 13; i++)
            {
                Tile tile = nowGeneratedTiles[i];

                if (tile.TileType == Define.TileType.LeafTypes)
                {
                    tile.ChangeFlower(i);      
                }
            }
        }
    }

    
}
