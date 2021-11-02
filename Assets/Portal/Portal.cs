using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PortalDirection
{
    Down,
    Up
}

public class Portal
{
    public int EnterPosition { get; }
    public int ExitPosition { get; }

    public PortalDirection PortalDirection { get; }

    private Portal(int enterPosition, int exitPosition)
    {
        EnterPosition = enterPosition;
        ExitPosition = exitPosition;
        PortalDirection = exitPosition < enterPosition ? PortalDirection.Down : PortalDirection.Up;
    }

    public static Portal Create(int enterPosition, int exitPosition)
    {
        return new Portal(enterPosition, exitPosition);
    }
}
