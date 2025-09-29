using UnityEngine;

public class GridManager3D : MonoBehaviour
{
    public int width = 5;
    public int height = 5;
    public float cellSize = 1.5f;
    public GameObject cellPrefab;

    private Cell[,] grid;

    void Awake()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid = new Cell[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject go = Instantiate(cellPrefab, transform);
                go.transform.position = new Vector3(x * cellSize, 0, y * cellSize);
                Cell cell = go.AddComponent<Cell>();
                cell.x = x;
                cell.y = y;
                grid[x, y] = cell;
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height) return null;
        return grid[x, y];
    }
}
