using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBloomItem : Item
{
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.gameObject.tag == "WingWing")
        {
            AllBloom();
        }
    }

    private void AllBloom()
    {
        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;

            for (int i = 1; i < 15; i++)
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
