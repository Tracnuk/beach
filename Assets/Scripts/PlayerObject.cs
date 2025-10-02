using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerObject : BaseObject
{
    [Header("Player Params")]
    public int turnsLeft = 4;
    public bool isSelected = false;

    [Header("Player Events")]
    public UnityEvent onSelect = new();
    public UnityEvent onDiselect = new();
    public UnityEvent onMove = new();

    private List<BaseTile> tilesAround;

    public override void Move(BaseTile tile)
    {
        if (turnsLeft <= 0 || tile.isOccupied || !tilesAround.Contains(tile) || !tile.isWalkable) return;

        UnhighlightTilesAround();

        Vector2Int tilePosition = tile.position;

        occupiedTile.ExitTile();
        occupiedTile = tile;
        occupiedTile.EnterTile(this);

        gameObject.name = $"{hierarchyName} at {tilePosition.x}:{tilePosition.y}";

        position = tilePosition;
        Vector3 newPosition = ObjectManager.instance.GridToWorldPosition(tilePosition);
        transform.LookAt(newPosition);
        transform.position = newPosition;
        turnsLeft--;

        HighlightTilesAround();

        onMove?.Invoke();
    }

    public void Select()
    {
        isSelected = true;
        EnableOutline();
        HighlightTilesAround();

        onSelect?.Invoke();
    }

    public void Diselect()
    {
        isSelected = false;
        DisableOutline();
        UnhighlightTilesAround();

        onDiselect?.Invoke();
    }

    public void HighlightTilesAround()
    {
        tilesAround = new List<BaseTile>() { };
        occupiedTile.EnableOutline(Color.blue);
        foreach (BaseTile tile in MapManager.instance.Get4TilesAround(position))
        {
            if (tile.isWalkable && !tile.isOccupied) { tilesAround.Add(tile); tile.EnableOutline((turnsLeft > 0) ? Color.green : Color.red); };
        }
    }

    public void UnhighlightTilesAround()
    {
        occupiedTile.DisableOutline();
        foreach (BaseTile tile in tilesAround)
        {
            tile.DisableOutline();
        }
    }

    private void OnMouseEnter()
    {
        if (isSelected) return;
        EnableOutline();
    }

    private void OnMouseExit()
    {
        if (isSelected) return;
        DisableOutline();
    }
}