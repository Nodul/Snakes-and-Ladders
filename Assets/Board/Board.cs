using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private BoardTile[] _boardTiles;

    public List<Token> Tokens { get; private set; }

    public List<Snake> Snakes { get; private set; }

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

    public bool IsTileSnakeHead(int tileNumber) 
    {
        return Snakes.Any(x => x.HeadPosition == tileNumber);
    }

    public int GetSnakeTailFromHead(int tileNumber) 
    {
        return Snakes.First(x => x.HeadPosition == tileNumber).TailPosition;
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
        Snakes = new List<Snake>();

        Snake testSnake = Snake.Create(2, 30);

        Snakes.Add(testSnake);

        var testSnake2 = Snake.Create(10, 34);

        Snakes.Add(testSnake2);
    }
}
