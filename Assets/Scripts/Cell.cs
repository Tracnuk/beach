using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x, y;
    public bool isOccupied = false;
    public Unit unit;

    // Методы выделения/снятия выделения
    public void Select()
    {
        // подсветка
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Метод для клика по клетке
    private void OnMouseDown()
    {
        if(!isOccupied)
        {
            // например, перемещение выбранного юнита
            PlayerController.Instance.TryMoveSelectedUnit(this);
        }
    }
}
