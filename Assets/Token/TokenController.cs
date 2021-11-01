using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    private TokenGO _token;
    private DiceGO _dice;

    private void Awake()
    {
        _dice = FindObjectOfType<DiceGO>();
    }

    public void AddPlayableToken(Token token, TokenGO tokenGO) 
    {
        tokenGO.InitToken(token);
        _token = tokenGO;
        _dice.DiceRolled += tokenGO.OnDiceRolled;
    }
}
