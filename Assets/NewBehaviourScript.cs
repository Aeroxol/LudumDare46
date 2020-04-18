using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewBehaviourScript : MonoBehaviour
{
    Vector3Int cellPosition;
    public TileBase square;
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap.BoxFill(new Vector3Int(0, 0, 0), square, 1, 10, 1, 10);
        Debug.Log(tilemap.GetCellCenterLocal(new Vector3Int(-6,-5,0)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
