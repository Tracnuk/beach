using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BaseTile : MonoBehaviour
{
    [Header("Params")]
    public bool isWalkable;

    [Header("Events")]
    public UnityEvent OnTileEnter = new();
    public UnityEvent OnTileExit = new();

    [Header("Debug")]
    public string hierarchyName;
    public BaseObject occupiedObject;
    public bool isOccupied => occupiedObject != null;
    
    public Vector2Int position;

    private SpriteRenderer outline;

    private void Awake()
    {
        outline = GetComponentInChildren<SpriteRenderer>();
        outline.enabled = false;
    }

    public void EnterTile(BaseObject _object)
    {
        occupiedObject = _object;
        OnTileEnter?.Invoke();
    }

    public void ExitTile()
    {
        occupiedObject = null;
        OnTileExit?.Invoke();
    }

    public void EnableOutline(Color color)
    {
        outline.color = color;
        outline.enabled = true;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public override bool Equals(object obj)
    {
        if (obj is BaseTile other)
        {
            return position == other.position;
        }
        return false;
    }
}
