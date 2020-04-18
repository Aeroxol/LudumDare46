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

    public void TestInitialize(int col, int row, OnTileObject groundPrefab, OnTileObject wallPrefab)
    {
        Vector3 origin = transform.position;

        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < col; x++)
            {
                Vector3 position = origin + new Vector3(x, y) * _tileSize;
                var tile = Instantiate(_tilePrefab, position, transform.rotation);
                tile.transform.parent = transform;

                tile.Initialize(this, x, y);

                var prefab = Random.value > 0.2 ? groundPrefab : wallPrefab;
                var onTileObject = Instantiate(prefab, tile.transform);
                tile.AddOnTileObject(onTileObject);
            }
        }
    }
}