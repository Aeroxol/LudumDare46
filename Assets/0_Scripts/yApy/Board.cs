using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private float _tileSize;
    [SerializeField] private Tile _tilePrefab;

    public Tile this[int x, int y]
    {
        get
        {
            if (!IsInBound(x, y)) return null;
            return _tiles[x, y];
        }
    }

    private Tile[, ] _tiles;

    private bool IsInBound(int x, int y)
    {
        return x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1);
    }
}
