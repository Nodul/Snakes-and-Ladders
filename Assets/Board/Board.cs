using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private BoardTile[] _boardTiles;

    public List<Token> Tokens { get; private set; }

    public List<Portal> Portals { get; private set; }

    public int SideLength { get; }

    public int Size => SideLength * SideLength;

    private Board(int size, int numOfTokens)
    {
        SideLength = size;
        CreateTiles();
        CreateTokens(numOfTokens);
        CreateSnakes();
    }

    public static Board Create(int sideLength, int numOfTokens) 
    {
        return new Board(sideLength, numOfTokens);
    }

    public BoardTile GetTile(int tileNumber) 
    {
        return _boardTiles[tileNumber - 1];
    }

    public bool IsTilePortalEntry(int tileNumber) 
    {
        return Portals.Any(x => x.EnterPosition == tileNumber);
    }

    public int GetPortalExitFromEntry(int tileNumber) 
    {
        return Portals.First(x => x.EnterPosition == tileNumber).ExitPosition;
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
            Tokens.Add(Token.Create(i + 1, this, Size));
        }
    }

    private void CreateSnakes() 
    {
        Portals = new List<Portal>();

        // Snakes
        Portals.Add(Portal.Create(30, 2));
        Portals.Add(Portal.Create(34, 10));

        // Ladders
        Portals.Add(Portal.Create(6, 25));
        Portals.Add(Portal.Create(18, 37));
    }
}
