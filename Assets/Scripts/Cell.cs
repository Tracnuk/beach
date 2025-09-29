using UnityEngine;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x, y;
    public bool isOccupied;
    public Unit unit;

    public void SetUnit(Unit newUnit)
    {
        unit = newUnit;
        isOccupied = newUnit != null;
    }
}
