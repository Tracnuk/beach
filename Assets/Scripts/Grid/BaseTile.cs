using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BaseTile : MonoBehaviour
{
    [Header("Params")]
    public bool isWalkable;

    [Header("Events")]
    public UnityEvent OnTurnStart;
    public UnityEvent OnTurnEnd;
    public UnityEvent OnTileEnter;
    public UnityEvent OnTileExit;

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
}
