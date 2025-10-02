using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[RequireComponent(typeof(Outline))]
public class BaseObject : MonoBehaviour
{
    [Header("Params")]
    public bool isObstacle;
    public bool canBeDamaged;
    public int HP;

    [Header("Events")]
    public UnityEvent OnDamage = new();
    public UnityEvent OnDestroy = new();
    public UnityEvent OnTurnEnd = new();
    public UnityEvent OnTurnStart = new();

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
    public void Damage(int dmg) {
        OnDamage.Invoke();

        HP -= dmg;

        if (HP <= 0) {
            HP = 0;
            Destroy();
        }
    }
    public void Destroy() { 
        OnDestroy.Invoke();
        Destroy(gameObject);
    }
    public void TurnEnd()
    {
        OnTurnEnd.Invoke();
    }
    public void TurnStart() { 
        OnTurnStart.Invoke();
    }

    public virtual void Update() { 
        if (Input.GetMouseButtonDown(1))
        {
            OnTurnEnd.Invoke();
            OnTurnStart.Invoke();
        }
    }
}
