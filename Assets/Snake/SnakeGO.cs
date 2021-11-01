using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGO : MonoBehaviour
{
    public static readonly Vector3 SnakeHeadOffset = new Vector3(0f, -0.25f, 0f);
    public static readonly Vector3 SnakeTailOffset = new Vector3(0f, 0.25f, 0f);
    public static readonly float SnakeScale = 0.5f;
    private List<SpriteRenderer> _spriteRenderers;

    private void Awake()
    {
        _spriteRenderers = new List<SpriteRenderer>();
    }

    public void RenderSnake(Vector3 tailPos, Sprite tailSprite, Vector3 headPos, Sprite headSprite, Sprite segmentSprite) 
    {
        var offsetHeadPos = headPos + SnakeHeadOffset;
        var offsetTailPos = tailPos + SnakeTailOffset;
        Vector3 direction = offsetHeadPos - offsetTailPos;
        if(direction.x < 0) 
        {
            direction.y = -direction.y;
        }
        
        RenderSprite(offsetTailPos, tailSprite, direction);
        RenderSprite(offsetHeadPos, headSprite, direction);
    }

    private void RenderSprite(Vector3 offsetPos, Sprite sprite, Vector3 direction) 
    {
        var n = new GameObject("Snake");

        n.transform.localPosition = offsetPos;

        var rotation = Quaternion.LookRotation(direction);
        rotation.x = n.transform.localRotation.x;
        rotation.y = n.transform.localRotation.y;
        n.transform.localRotation = rotation;

        n.transform.localScale *= SnakeScale;
        n.transform.SetParent(transform, true);
        var spriteRenderer = n.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingLayerName = "Snakes";
        _spriteRenderers.Add(spriteRenderer);
    }
}
