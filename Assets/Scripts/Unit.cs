using UnityEngine;

public class Unit : MonoBehaviour
{
    public Cell currentCell; // клетка, на которой стоит юнит

    // Метод для установки на клетку
    public void Place(Cell cell)
    {
        currentCell = cell;
        transform.position = cell.transform.position + Vector3.up * 0.5f; // смещение по высоте
        cell.unit = this;
        cell.isOccupied = true;
    }

    // Метод для перемещения на другую клетку
    public void MoveTo(Cell targetCell)
    {
        if(targetCell == null || targetCell.isOccupied) return;

        if(currentCell != null)
        {
            currentCell.unit = null;
            currentCell.isOccupied = false;
        }

        Place(targetCell);
    }

    // Метод, вызываемый при клике на юнит
    private void OnMouseDown()
    {
        Debug.Log("Выбран юнит: " + name);
        // Здесь можно вызвать селект юнита, показать действия и т.д.
    }
}
