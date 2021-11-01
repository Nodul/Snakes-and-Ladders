using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardRenderer : MonoBehaviour
{
    [SerializeField]
    private int _boardSizeLength;

    [SerializeField]
    private Sprite _boardTileSprite;

    [SerializeField]
    private GameObject _boardTileLabelPrefab;

    private Board _board;

    private void Awake()
    {
        _board = Board.Create(_boardSizeLength);
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
            if (i % _boardSizeLength == 1)
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
            spriteRenderer.sprite = _boardTileSprite;

            var text = Instantiate(_boardTileLabelPrefab);
            text.transform.localPosition = boardTileGO.transform.localPosition;
            text.transform.SetParent(boardTileGO.transform, true);
            text.GetComponentInChildren<TextMeshProUGUI>().text = $"{i}";
        }
    }
}
