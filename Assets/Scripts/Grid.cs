using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid Instance { get; private set; } 

    public GameObject baseTile;
    public GameObject[,] tiles;

    public int xSize = 10;
    public int ySize = 10;
    public int cellSize = 2;

    [ContextMenu("Generate Grid")]
    public void GenerateGrid()
    {
        tiles = new GameObject[xSize, ySize];

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                tiles[x, y] = Instantiate(baseTile, transform);
                tiles[x, y].GetComponent<Tile>().SetPosition(x, y);
                tiles[x, y].transform.localPosition = new Vector3(x, 0, y)* cellSize;
                tiles[x, y].name = string.Format("Tile {0}:{1}", x, y);
            }
        }
    }

    [ContextMenu("Destroy Grid")]
    public void DestroyGrid()
    {
        foreach (GameObject tile in tiles)
        {
            DestroyImmediate(tile);
        }
    }
}
