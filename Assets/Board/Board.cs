using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private BoardTile[] _boardTiles;

    private Token _token;

    public int SideLength { get; }

    public int Size => SideLength * SideLength;

    private Board(int size)
    {
        SideLength = size;
        CreateTiles();
        CreateTokens();
    }

    public static Board Create(int sideLength) 
    {
        return new Board(sideLength);
    }

    public BoardTile GetTile(int tileNumber) 
    {
        return _boardTiles[tileNumber - 1];
    }

    private void CreateTiles() 
    {
        _boardTiles = new BoardTile[Size];

        for (int i = 0; i < Size; i++) 
        {
            _boardTiles[i] = BoardTile.Create(i);
        }
    }

    private void CreateTokens() 
    {
        _token = Token.Create();
    }
}
