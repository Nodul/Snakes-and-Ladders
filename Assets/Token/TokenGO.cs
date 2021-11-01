using System;
using System.Collections.Generic;
using UnityEngine;

public class TokenGO : MonoBehaviour
{
    public readonly float TokenZOffset = -0.1f;
    public Sprite TokenSprite;
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
    }

    public void OnDiceRolled(int result) 
    {        
        Token.MoveTokenByAmount(result);
        TokenMoved?.Invoke(this);
    }
}
