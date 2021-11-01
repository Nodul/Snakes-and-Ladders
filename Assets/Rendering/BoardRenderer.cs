using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardRenderer : MonoBehaviour
{
    public int BoardSizeLength;
    [Range(1, 4)]
    public int NumberOfTokens; 
    public Sprite[] BoardTileSprites;
    public Sprite BoardTileSprite1;
    public Sprite BoardTileSprite2;
    public Sprite BoardTileSprite3;
    public Sprite BoardTileSprite4;
    public TokenGO TokenPrefab;

    public Sprite SnakeTailSprite;
    public Sprite SnakeSegmentSprite;
    public Sprite SnakeHeadSprite;

    private int _currentBoardTileSpriteIndex = 1;
    private Sprite[] _spriteBoardTilesWorkaround;

    [SerializeField]
    private GameObject _boardTileLabelPrefab;

    private Board _board;

    private Dictionary<int, Vector2> _boardTilesPositions;

    private void Awake()
    {
        _boardTilesPositions = new Dictionary<int, Vector2>();
        _board = Board.Create(BoardSizeLength, NumberOfTokens);
        // HACK I had to use this workaround because the normal BoardTileSprites array seems to be bugged in my UnityEditor, and I cannot assign sprites there
        _spriteBoardTilesWorkaround = new Sprite[]
        {
            BoardTileSprite1, BoardTileSprite2, BoardTileSprite3, BoardTileSprite4
        };
    }

    // Start is called before the first frame update
    private void Start()
    {
        RenderBoard();
    }

    private void RenderBoard()
    {
        int x = 0;
        int y = 0;
        bool yChangedThisLoop = false;

        for (int i = 1; i <= _board.Size; i++)
        {
            if (i % BoardSizeLength == 1)
            {
                y++;
                yChangedThisLoop = true;
            }

            if (!yChangedThisLoop)
            {
                if (y % 2 == 0)
                {
                    x--;
                }
                else
                {
                    x++;
                }
            }

            _boardTilesPositions.Add(i, new Vector2(x, y));

            yChangedThisLoop = false;

            var boardTileGO = new GameObject($"[{i}]");
            boardTileGO.transform.localPosition = new Vector3(x, y, 0);
            boardTileGO.transform.SetParent(transform, true);

            var spriteRenderer = boardTileGO.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GetNextTileSprite();

            var text = Instantiate(_boardTileLabelPrefab);
            text.transform.localPosition = boardTileGO.transform.localPosition;
            text.transform.SetParent(boardTileGO.transform, true);
            text.GetComponentInChildren<TextMeshProUGUI>().text = $"{i}";

            if (i == 1)
            {
                RenderTokens(x, y);
            }         
        }

        RenderSnakes();
    }

    private Sprite GetNextTileSprite()
    {
        var sprite = _spriteBoardTilesWorkaround[_currentBoardTileSpriteIndex];
        _currentBoardTileSpriteIndex++;
        if (_currentBoardTileSpriteIndex == _spriteBoardTilesWorkaround.Length)
        {
            _currentBoardTileSpriteIndex = 0;
        }

        return sprite;
    }

    private void RenderTokens(int xStartPos, int yStartPos)
    {
        foreach(var token in _board.Tokens) 
        {
            var tokenGO = Instantiate<TokenGO>(TokenPrefab);         
            
            tokenGO.TokenMoved += RerenderToken;
            FindObjectOfType<TokenController>().AddPlayableToken(token, tokenGO);
            tokenGO.transform.localPosition = new Vector3(xStartPos, yStartPos, 0f) + tokenGO.TokenPositionOffset;

            var spriteRenderer = tokenGO.GetComponent<SpriteRenderer>();
            spriteRenderer.color = tokenGO.TokenColor;
            spriteRenderer.sortingLayerName = "Tokens";
        }
    }

    private void RerenderToken(TokenGO tokenToMove) 
    {
        var pos2D = _boardTilesPositions[tokenToMove.CurrentPosition];
        tokenToMove.transform.localPosition = new Vector3(pos2D.x, pos2D.y, 0f) + tokenToMove.TokenPositionOffset;
    }

    private void RenderSnakes() 
    {
        foreach(var snake in _board.Snakes) 
        {
            var tailPosInWorld = _boardTilesPositions[snake.TailPosition];
            var headPosInWorld = _boardTilesPositions[snake.HeadPosition];

            var newSnakeGO = new GameObject("Snake");
            var snakeGO = newSnakeGO.AddComponent<SnakeGO>();
            
            snakeGO.RenderSnake(tailPosInWorld, SnakeTailSprite, headPosInWorld, SnakeHeadSprite, SnakeSegmentSprite);
        }
    }
}
