using System;
using System.Collections.Generic;
using UnityEngine;

public class TokenGO : MonoBehaviour
{
    public static readonly float TokenZOffset = -0.1f;
    public static readonly float TokenCardinalOffset = 0.25f;
    public static Vector3[] AvailableTokenPositionOffsets =
    {
        new Vector3(TokenCardinalOffset, TokenCardinalOffset, TokenZOffset),
        new Vector3(TokenCardinalOffset, -TokenCardinalOffset, TokenZOffset),
        new Vector3(-TokenCardinalOffset, -TokenCardinalOffset, TokenZOffset),
        new Vector3(-TokenCardinalOffset, TokenCardinalOffset, TokenZOffset)
    };
    public static Color[] AvailableTokenColors =
        {
        Color.red,
        Color.blue,
        Color.green,
        Color.black
    };
    public Vector3 TokenPositionOffset;
    public Sprite TokenSprite;
    public Color TokenColor;
    public event Action<TokenGO> TokenMoved;
    public int CurrentPosition => Token.CurrentPosition;

    public Token Token { get; private set; }


    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InitToken(Token token)
    {
        Token = token;
        TokenPositionOffset = AvailableTokenPositionOffsets[token.Id - 1];
        TokenColor = AvailableTokenColors[token.Id - 1];
    }

    public void OnDiceRolled(int result)
    {
        Token.MoveTokenByAmount(result);
        TokenMoved?.Invoke(this);
    }
}
