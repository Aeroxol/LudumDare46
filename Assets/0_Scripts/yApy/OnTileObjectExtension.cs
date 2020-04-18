using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OnTileObjectExtension
{
    public static void Move(this OnTileObject onTileObject, Tile newTile, bool adjustPosition = true)
    {
        if (onTileObject == null) return;
        if (onTileObject.Tile == null) return;

        onTileObject.Tile.RemoveOnTileObject(onTileObject);
        newTile.AddOnTileObject(onTileObject, adjustPosition);
    }
}
