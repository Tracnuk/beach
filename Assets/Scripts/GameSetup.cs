using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public GridManager3D gridManager;
    public Unit playerPrefab;

    void Start()
    {
        // Спавним игрока в левый нижний угол
        Cell startCell = gridManager.GetCell(0, 0);
        Unit player = Instantiate(playerPrefab);
        player.Place(startCell);
    }
}
