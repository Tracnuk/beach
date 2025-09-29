using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public enum Turn { Player, Enemy }
    public Turn CurrentTurn { get; private set; } = Turn.Player;

    void Awake()
    {
        Instance = this;
    }

    public void EndPlayerTurn()
    {
        CurrentTurn = Turn.Enemy;
        StartCoroutine(EnemyTurn());
    }

    private System.Collections.IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy turn...");

        Unit[] enemies = FindObjectsOfType<Unit>();
        foreach (Unit enemy in enemies)
        {
            if (!enemy.isEnemy) continue;

            // Враг двигается на 1 клетку вниз (пример логики)
            Cell target = enemy.currentCell;
            GridManager grid = FindObjectOfType<GridManager>();
            Cell downCell = grid.GetCell(target.x, target.y - 1);

            if (downCell != null && !downCell.isOccupied)
                enemy.MoveTo(downCell);

            yield return new WaitForSeconds(0.5f);
        }

        CurrentTurn = Turn.Player;
        Debug.Log("Player turn!");
    }
}
