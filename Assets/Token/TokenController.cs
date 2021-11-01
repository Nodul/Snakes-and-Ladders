using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenController : MonoBehaviour
{
    public GameObject VictoryPanel;
    private TokenGO _tokenGO;
    private DiceGO _diceGO;

    private void Awake()
    {
        _diceGO = FindObjectOfType<DiceGO>();
    }

    public void AddPlayableToken(Token token, TokenGO tokenGO) 
    {
        tokenGO.InitToken(token);
        token.TokenFinished += OnTokenFinished;
        _tokenGO = tokenGO;
        
        _diceGO.DiceRolled += tokenGO.OnDiceRolled;
    }

    private void OnTokenFinished(Token token) 
    {
        VictoryPanel.gameObject.SetActive(true);
        _diceGO.gameObject.SetActive(false);
    }
}
