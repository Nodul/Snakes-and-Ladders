using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private BoardTile[] _boardTiles;

    public List<Token> Tokens { get; private set; }

    public int SideLength { get; }

    public int Size => SideLength * SideLength;

    private Board(int size, int numOfTokens)
    {
        SideLength = size;
        CreateTiles();
        CreateTokens(numOfTokens);
    }

    public static Board Create(int sideLength, int numOfTokens) 
    {
        return new Board(sideLength, numOfTokens);
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

    private void CreateTokens(int numOfTokens) 
    {
        Tokens = new List<Token>();
        for(int i = 0; i < numOfTokens; i++) 
        {
            Tokens.Add(Token.Create(i + 1, Size));
        }
    }
}
