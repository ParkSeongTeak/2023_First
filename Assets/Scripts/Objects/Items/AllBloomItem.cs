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
        int cnt = 0;
        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;

            for (int i = 1; i < 15; i++)
            {
                Tile tile = nowGeneratedTiles[i];

                if (tile.TileType == Define.TileType.FlowerTypes)
                {
                    if (cnt == 0)
                    {
                        GameUI.Instance.timeSlider.PlusTime();
                        cnt++;
                    }
                    tile.AllBloom();
                }
            }
        }
    }
}
