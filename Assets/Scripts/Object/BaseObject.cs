using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BaseObject : MonoBehaviour
{

    [Header("Params")]
    public bool isObstacle;
    public bool canBeDamaged;
    public int HP;

    [Header("Events")]
    public UnityEvent OnTurnStart = new();
    public UnityEvent OnTurnEnd = new();
    public UnityEvent OnDamage = new();
    public UnityEvent OnDestroy = new();

    [Header("Debug")]
    public string hierarchyName;
    public BaseTile occupiedTile;
    public Vector2Int position;

    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void EnableOutline(Color color)
    {
        outline.OutlineColor = color;
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
