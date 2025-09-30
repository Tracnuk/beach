using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public enum BattleState { PlayerTurn, EnemyTurn }
    public BattleState battleState = BattleState.PlayerTurn;

    public UnityEvent OnPlayerTurnStart = new();
    public UnityEvent OnPlayerTurnEnd = new();

    public UnityEvent OnEnemyTurnStart = new();
    public UnityEvent OnEnemyTurnEnd = new();

    public BaseUnit playerUnit;
    public List<BaseUnit> enemyUnits;
}
