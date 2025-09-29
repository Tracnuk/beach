using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public Unit SelectedUnit;

    void Awake() => Instance = this;

    public void SelectUnit(Unit unit)
    {
        SelectedUnit = unit;
        Debug.Log("Selected: " + unit.name);
    }
}
