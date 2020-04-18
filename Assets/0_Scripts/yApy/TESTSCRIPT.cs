using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSCRIPT : MonoBehaviour
{
    public Board board;
    public int col;
    public int row;

    public OnTileObject ground;
    public OnTileObject wall;

    private void Start()
    {
        board.TestInitialize(col, row, ground, wall);
    }
}
