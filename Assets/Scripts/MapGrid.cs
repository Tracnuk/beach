using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    [SerializeField, Range(0, 10)] private float tileSpacing;
    [SerializeField] private BaseTile prefab;
    [SerializeField] private List<BaseTile> tiles;

    private void OnValidate()
    {
        gridSize = new((int)Mathf.Clamp(gridSize.x, 0, Mathf.Infinity), (int)Mathf.Clamp(gridSize.y, 0, Mathf.Infinity));
    }

    public void GenerateGrid()
    {
        ClearGrid();
        tiles = new List<BaseTile>();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 position = new(x * tileSpacing, 0, y * tileSpacing);

                BaseTile tile = Instantiate(prefab, position + transform.position, Quaternion.identity, transform);

                tile.Initialize(new Vector2Int(x, y));

                tiles.Add(tile);
            }
        }
    }

    public void ClearGrid()
    {
        foreach (BaseTile tile in tiles)
        {
            DestroyImmediate(tile.gameObject);
        }

        tiles.Clear();
    }
}
