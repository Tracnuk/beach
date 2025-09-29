using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Unit selectedUnit;

    void Update()
    {
        if (TurnManager.Instance.CurrentTurn != TurnManager.Turn.Player) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Cell cell = hit.collider.GetComponent<Cell>();
                if (cell == null) return;

                if (cell.unit != null && !cell.unit.isEnemy)
                {
                    selectedUnit = cell.unit;
                    Debug.Log($"Selected {selectedUnit.unitName}");
                }
                else if (selectedUnit != null && !cell.isOccupied)
                {
                    selectedUnit.MoveTo(cell);
                    selectedUnit = null;

                    TurnManager.Instance.EndPlayerTurn();
                }
            }
        }
    }
}
