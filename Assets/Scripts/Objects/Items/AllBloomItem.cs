using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBloomItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        AllBloom();
    }

    private void AllBloom()
    {
        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;

            for (int i = 5; i < 15; i++)
            {
                Tile tile = nowGeneratedTiles[i];

                if (tile.TileType == Define.TileType.FlowerTypes)
                {
                    tile.AllBloom();
                }
            }
        }
    }
}
