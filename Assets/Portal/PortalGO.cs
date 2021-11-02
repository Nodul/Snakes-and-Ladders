using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGO : MonoBehaviour
{
    public static readonly Vector3 EntryOffset = new Vector3(0f, -0.25f, 0f);
    public static readonly Vector3 ExitOffset = new Vector3(0f, 0.25f, 0f);
    public static readonly float Scale = 0.5f;
    private List<SpriteRenderer> _spriteRenderers;

    private void Awake()
    {
        _spriteRenderers = new List<SpriteRenderer>();
    }

    public void RenderPortal(Portal portal, Vector3 exitPos, Sprite exitSprite, Vector3 entryPos, Sprite entrySprite, Sprite segmentSprite) 
    {
        var offsetEntryPos = entryPos + (portal.PortalDirection == PortalDirection.Down ? EntryOffset : -EntryOffset);
        var offsetExitPos = exitPos + (portal.PortalDirection == PortalDirection.Down ? ExitOffset : -ExitOffset);
        Vector3 direction = offsetEntryPos - offsetExitPos;        
        RenderSprite(offsetExitPos, exitSprite, direction);

        var howManySegmentsNeededToReachEntryFromExit = Mathf.CeilToInt(direction.magnitude - segmentSprite.bounds.size.y) * 2 + 1;
        for (int i = 1; i <= howManySegmentsNeededToReachEntryFromExit; i++)
        {
            var segmentOffset = direction / howManySegmentsNeededToReachEntryFromExit;
            RenderSprite(offsetExitPos + segmentOffset * i, segmentSprite, direction);
        }

        RenderSprite(offsetEntryPos, entrySprite, direction);
    }

    private void RenderSprite(Vector3 offsetPos, Sprite sprite, Vector3 direction) 
    {
        var n = new GameObject("Snake");

        n.transform.localPosition = offsetPos;

        var rotation = Quaternion.LookRotation(direction);
        rotation.x = n.transform.localRotation.x;
        rotation.y = n.transform.localRotation.y;
        n.transform.localRotation = rotation;

        n.transform.localScale *= Scale;
        n.transform.SetParent(transform, true);
        var spriteRenderer = n.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingLayerName = "Portals";
        _spriteRenderers.Add(spriteRenderer);
    }
}
