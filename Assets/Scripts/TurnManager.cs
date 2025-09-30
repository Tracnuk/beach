using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public enum BattleState { PlayerTurn, EnemyTurn }
    public BattleState battleState = BattleState.PlayerTurn;

    public BaseUnit playerUnit;
    public List<BaseUnit> enemyUnits;

    public UnityEvent OnPlayerTurnStart = new();
    public UnityEvent OnPlayerTurnEnd = new();

    public UnityEvent OnEnemyTurnStart = new();
    public UnityEvent OnEnemyTurnEnd = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EndTurn()
    {
        if (battleState is BattleState.PlayerTurn)
        {
            OnPlayerTurnEnd?.Invoke();
            OnEnemyTurnStart?.Invoke();
            battleState = BattleState.EnemyTurn;
            return;
        }
        else if (battleState is BattleState.EnemyTurn)
        {
            OnEnemyTurnEnd?.Invoke();
            OnPlayerTurnStart?.Invoke();
            battleState = BattleState.PlayerTurn;
            return;
        }
    }
}
