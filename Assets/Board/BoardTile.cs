using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile
{
    public int TileNumber { get; }

    private BoardTile (int tileNumber) 
    {
        TileNumber = tileNumber;
    }

    public static BoardTile Create(int tileNumber) 
    {
        return new BoardTile(tileNumber);
    }
}
