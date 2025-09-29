using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Unit selectedUnit;

    private void Awake() => Instance = this;

    public void SelectUnit(Unit unit)
    {
        selectedUnit = unit;
        Debug.Log("Селект: " + unit.name);
    }

    public void TryMoveSelectedUnit(Cell targetCell)
    {
        if(selectedUnit != null)
        {
            selectedUnit.MoveTo(targetCell);
        }
    }
}
