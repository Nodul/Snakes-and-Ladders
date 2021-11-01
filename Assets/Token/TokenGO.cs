using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenGO : MonoBehaviour
{
    public Sprite TokenSprite;

    private Token _token;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
