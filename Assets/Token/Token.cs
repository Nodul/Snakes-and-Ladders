using System;
using System.Collections.Generic;
using UnityEngine;

public class Token
{
    private int _finalTileNumber;

    private Board _board;

    public int Id { get; private set; }

    public int CurrentPosition { get; private set; }

    public TokenState TokenState { get; private set; }

    public event Action<Token> TokenFinished;

    private Token(int id, int finalTileNumber, Board board)
    {
        Id = id;
        _board = board;
        _finalTileNumber = finalTileNumber;
        CurrentPosition = 1; // All tokens start at position 1
        TokenState = TokenState.Playing;
    }

    public static Token Create(int id, Board board, int finalTileNumber)
    {
        return new Token(id, finalTileNumber, board);
    }

    public void MoveTokenByAmount(int amountToMove)
    {
        if (TokenState != TokenState.Playing)
        {
            return;
        }

        if (CurrentPosition + amountToMove > _finalTileNumber)
        {
            // too far, need to bounce from final tile
            CurrentPosition -= (CurrentPosition + amountToMove) - _finalTileNumber - 1;
        }
        else
        {
            // Continue normally
            CurrentPosition += amountToMove;

            if (_board.IsTileSnakeHead(CurrentPosition)) 
            {
                var snakeTailPos = _board.GetSnakeTailFromHead(CurrentPosition);
                var amountToBacktrack = CurrentPosition - snakeTailPos;
                CurrentPosition -= amountToBacktrack;
                return;
            }

            if (CurrentPosition == _finalTileNumber)
            {
                // player has reached the final tile
                Debug.Log("Victory!");
                TokenState = TokenState.Finished;
                TokenFinished?.Invoke(this);
            }
        }
    }
}
