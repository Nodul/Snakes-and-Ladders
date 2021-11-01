using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenController : MonoBehaviour
{
    public GameObject VictoryPanel;
    private List<TokenGO> _tokenGOs;
    private DiceGO _diceGO;
    private int _currentTokenToMoveIndex = 0;

    private void Awake()
    {
        _diceGO = FindObjectOfType<DiceGO>();
        _tokenGOs = new List<TokenGO>();
        _diceGO.DiceRolled += OnDiceRolled;
    }

    public void AddPlayableToken(Token token, TokenGO tokenGO) 
    {
        tokenGO.InitToken(token);
        token.TokenFinished += OnTokenFinished;
        _tokenGOs.Add(tokenGO);
    }

    private void OnDiceRolled(int result) 
    {
        _tokenGOs[_currentTokenToMoveIndex].OnDiceRolled(result);
        _currentTokenToMoveIndex++;
        if(_currentTokenToMoveIndex >= _tokenGOs.Count) 
        {
            _currentTokenToMoveIndex = 0;
        }
    }

    private void OnTokenFinished(Token token) 
    {
        VictoryPanel.gameObject.SetActive(true);
        _diceGO.gameObject.SetActive(false);
    }
}
