using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafToFlowerItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        LeafToFlower();
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
