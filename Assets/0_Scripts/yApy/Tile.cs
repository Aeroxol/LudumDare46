using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private List<OnTileObject> _onTileObjects = new List<OnTileObject>();
    private Board _board;
    private int _x;
    private int _y;

    public void Initialize(Board board, int x, int y)
    {
        _board = board;
        _x     = x;
        _y     = y;
    }

    public T GetOnTileObject<T>() where T : OnTileObject
    {
        foreach (var onTileObject in _onTileObjects)
        {
            if (onTileObject is T) return onTileObject as T;
        }
        return default;
    }

    public void AddOnTileObject(OnTileObject onTileObject, bool adjustPosition = true)
    {
        onTileObject.OnEnterTile(this);

        _onTileObjects.ForEach(other => other.OnOtherEnter(onTileObject));
        _onTileObjects.Add(onTileObject);
        
        onTileObject.Tile = this;

        if (adjustPosition) onTileObject.transform.position = transform.position;
    }

    public bool RemoveOnTileObject(OnTileObject onTileObject)
    {
        if (!_onTileObjects.Remove(onTileObject)) return false;
        onTileObject.OnExitTile(this);

        onTileObject.Tile = null;

        _onTileObjects.ForEach(other => other.OnOtherExit(onTileObject));
        return true;
    }

    public Tile GetAdjacentTile(int offsetX, int offsetY)
    {
        return _board[_x + offsetX, _y + offsetY];
    }

    public Tile GetAdjacentTile(Vector2Int offset)
    {
        return GetAdjacentTile(offset.x, offset.y);
    }

    public T GetAdjacent<T>(int offsetX, int offsetY) where T : OnTileObject
    {
        var tile = GetAdjacentTile(offsetX, offsetY);
        if (tile == null) return default;

        return tile.GetOnTileObject<T>();
    }

    public T GetAdjacent<T>(Vector2Int offset) where T : OnTileObject
    {
        return GetAdjacent<T>(offset.x, offset.y);
    }

    public Vector2Int Difference(Tile targetTile)
    {
        return new Vector2Int(targetTile._x - _x, targetTile._y - _y);
    }

    public override string ToString()
    {
        return string.Format($"Tile on {_board} ({_x}, {_y})");
    }
}
