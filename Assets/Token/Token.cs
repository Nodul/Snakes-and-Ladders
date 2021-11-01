using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token
{
    public int CurrentPosition { get; private set; }

    private Token()
    {
        CurrentPosition = 1;
    }

    public static Token Create() 
    {
        return new Token();
    }

    public void MoveTokenByAmount(int amountToMove) 
    {
        CurrentPosition += amountToMove;
    }
}
