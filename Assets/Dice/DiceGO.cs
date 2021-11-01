using System;
using System.Collections.Generic;
using UnityEngine;

public class DiceGO : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;

    private Dice _dice;
    private SpriteRenderer _spriteRenderer;
    private Sprite[] _spriteSheedWorkaround;

    public event Action<int> DiceRolled;

    private void Awake()
    {
        _dice = Dice.Create();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteSheedWorkaround = new Sprite[]
        {
            Sprite1, Sprite2, Sprite3, Sprite4, Sprite5, Sprite6
        };
    }

    private void OnMouseDown()
    {
        RollDice();
    }

    public int RollDice() 
    {
        var result = _dice.RollDice();

        _spriteRenderer.sprite = _spriteSheedWorkaround[result - 1];

        DiceRolled?.Invoke(result);

        return result;
    }
}
