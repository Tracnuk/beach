using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BaseTile : MonoBehaviour
{
    [HideInInspector] public Vector2Int position;
    [HideInInspector] public MapManager manager;

    [Header("Params")]
    public bool isWalkable;

    [Header("Events")]
    public UnityEvent OnTurnStart;
    public UnityEvent OnTurnEnd;
    public UnityEvent OnTileEnter;
    public UnityEvent OnTileExit;

    [Header("Debug")]
    public GameObject occupiedObject;
    public bool isOccupied;
}
