using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperItem : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Jumper();
    }

    private void Jumper()
    {
        TileController tileController = TileController.Instance;

        if (tileController != null)
        {
            List<Tile> nowGeneratedTiles = tileController.NowGeneratedTiles;

            for (int i = 3; i <= 13; i++)
            {
                Tile tile = nowGeneratedTiles[i];

                if (tile.TileType == Define.TileType.FlowerTypes)
                {
                    GameManager.InGameDataManager.NowState.BloomCnt++;
                }
                else if (tile.TileType == Define.TileType.BonusTileTypes)
                {
                    //after confirm
                }
                TileController.Instance.MoveTiles();
            }
        }
    }
}
