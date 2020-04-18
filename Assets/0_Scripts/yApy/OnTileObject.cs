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
}
