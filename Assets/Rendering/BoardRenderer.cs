using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardRenderer : MonoBehaviour
{
    public int BoardSizeLength;

    public Sprite[] BoardTileSprites;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;

    private int _currentBoardTileSpriteIndex = 1;

    [SerializeField]
    private GameObject _boardTileLabelPrefab;

    private Board _board;

    private void Awake()
    {
        _board = Board.Create(BoardSizeLength);
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

            yChangedThisLoop = false;

            var boardTileGO = new GameObject($"[{i}]");
            boardTileGO.transform.localPosition = new Vector3(x, y, 0);
            boardTileGO.transform.SetParent(transform, true);

            var spriteRenderer = boardTileGO.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GetNextTileSpriteWorkaround();

            var text = Instantiate(_boardTileLabelPrefab);
            text.transform.localPosition = boardTileGO.transform.localPosition;
            text.transform.SetParent(boardTileGO.transform, true);
            text.GetComponentInChildren<TextMeshProUGUI>().text = $"{i}";
        }
    }

    /// <summary>
    /// Ugly workaround, because my UnityEditor is bugged and doesn't display array elements in the Inspector. 
    /// </summary>
    /// <returns></returns>
    private Sprite GetNextTileSpriteWorkaround() 
    {
        Sprite sprite = null;

        if(_currentBoardTileSpriteIndex == 1) 
        {
            sprite = Sprite1;
        }
        else if (_currentBoardTileSpriteIndex == 2)
        {
            sprite = Sprite2;
        }
        else if (_currentBoardTileSpriteIndex == 3)
        {
            sprite = Sprite3;
        }
        else if (_currentBoardTileSpriteIndex == 4)
        {
            sprite = Sprite4;
        }

        _currentBoardTileSpriteIndex++;
        if (_currentBoardTileSpriteIndex > 4)
        {
            _currentBoardTileSpriteIndex = 1;
        }

        return sprite;
    }

    /// <summary>
    /// Normally I would use this implementation, but my UnityEditor seems have a bug which prevents from assigning elements to arrays in the editor
    /// </summary>
    /// <returns></returns>
    private Sprite GetNextTileSprite()
    {
        var sprite = BoardTileSprites[_currentBoardTileSpriteIndex];
        _currentBoardTileSpriteIndex++;
        if(_currentBoardTileSpriteIndex == BoardTileSprites.Length) 
        {
            _currentBoardTileSpriteIndex = 0;
        }

        return sprite;
    }
}
