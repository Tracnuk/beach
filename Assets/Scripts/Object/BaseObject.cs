using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BaseObject : MonoBehaviour
{
    [HideInInspector] public Vector2Int position;
    [HideInInspector] public ObjectManager manager;

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
    public GameObject occupiedObject;
    public bool isOccupied;
}
