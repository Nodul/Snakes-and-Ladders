using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake
{
    public int TailPosition { get; private set; }
    public int HeadPosition { get; private set; }

    private Snake(int tailPosition, int headPosition) 
    {
        TailPosition = tailPosition;
        HeadPosition = headPosition;
    }

    public static Snake Create(int tailPosition, int headPosition) 
    {
        return new Snake(tailPosition, headPosition);
    }
}
