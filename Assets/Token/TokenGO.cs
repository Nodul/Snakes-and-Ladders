using System;
using System.Collections.Generic;
using UnityEngine;

public class TokenGO : MonoBehaviour
{
    public Sprite TokenSprite;
    public event Action<TokenGO> TokenMoved;
    public int CurrentPosition => _token.CurrentPosition;

    private Token _token;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InitToken(Token token) 
    {
        _token = token;
    }

    public void OnDiceRolled(int result) 
    {
        _token.MoveTokenByAmount(result);
        TokenMoved?.Invoke(this);
    }
}
