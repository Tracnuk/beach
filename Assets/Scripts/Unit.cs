using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int hp = 10;
    public int attackDamage = 2;
    public bool isEnemy = false;

    public Cell currentCell;

    public void Place(Cell cell)
    {
        if (currentCell != null)
            currentCell.SetUnit(null);

        currentCell = cell;
        currentCell.SetUnit(this);
        transform.position = cell.transform.position;
    }

    public void MoveTo(Cell targetCell)
    {
        if (targetCell == null || targetCell.isOccupied) return;
        Place(targetCell);
    }

    public void Attack(Unit target)
    {
        if (target == null) return;
        target.TakeDamage(attackDamage);
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    void Die()
    {
        if (currentCell != null)
            currentCell.SetUnit(null);

        Destroy(gameObject);
    }
}
