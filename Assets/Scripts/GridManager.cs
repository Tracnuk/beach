using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 8;
    public int height = 8;
    public GameObject cellPrefab;

    private Cell[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject cellObj = Instantiate(cellPrefab, new Vector3(x, 0, y), Quaternion.identity);
                cellObj.name = $"Cell {x},{y}";

                Cell cell = cellObj.GetComponent<Cell>();
                cell.x = x;
                cell.y = y;
                grid[x, y] = cell;
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height)
            return null;
        return grid[x, y];
    }
}
