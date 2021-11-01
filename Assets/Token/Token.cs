using System;
using System.Collections.Generic;
using UnityEngine;

public class Token
{
    private int _finalTileNumber;

    public int CurrentPosition { get; private set; }

    public TokenState TokenState { get; private set; }

    public event Action<Token> TokenFinished;

    private Token(int finalTileNumber)
    {
        _finalTileNumber = finalTileNumber;
        CurrentPosition = 1; // All tokens start at position 1
        TokenState = TokenState.Playing;
    }

    public static Token Create(int finalTileNumber)
    {
        return new Token(finalTileNumber);
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
