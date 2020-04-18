using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTileObject : MonoBehaviour
{
	public Tile Tile { get; set; }
	public virtual void OnEnterTile(Tile tile) { }
	public virtual void OnExitTile(Tile tile) { }
	public virtual void OnOtherEnter(OnTileObject other) { }
	public virtual void OnOtherExit(OnTileObject other) { }

    public static void MoveTo(OnTileObject onTileObject, Tile newTile, bool adjustPosition = true)
    {
        if (newTile == null)              return;
        if (onTileObject == null)         return;
        if (onTileObject.Tile == null)    return;
        if (onTileObject.Tile == newTile) return;

        onTileObject.Tile.RemoveOnTileObject(onTileObject);
        newTile.AddOnTileObject(onTileObject, adjustPosition);
    }
}
