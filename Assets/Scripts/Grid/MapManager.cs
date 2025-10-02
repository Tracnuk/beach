using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    public Vector2Int mapSize;
    public float tileSize = 2;

    [SerializeField] private BaseTile[] tilesFlat;
    public BaseTile[] tiles;

    [HideInInspector] public static MapManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public BaseTile GetTile(int x, int y)
    {
        return tilesFlat[y * mapSize.x + x];
    }

    public BaseTile GetInitializedTile(int x, int y)
    {
        return tiles[y * mapSize.x + x];
    }

    public BaseTile GetInitializedTile(Vector2Int position)
    {
        return tiles[position.y * mapSize.x + position.x];
    }

    public Vector3 GridToWorldPosition(int x, int y)
    {
        return transform.position + new Vector3((float)x * tileSize, 0, (float)y * tileSize);
    }
    public Vector3 GridToWorldPosition(Vector2Int position)
    {
        return transform.position + new Vector3((float)position.x * tileSize, 0, (float)position.y * tileSize);
    }
    public void SetTile(int x, int y, BaseTile tile)
    {
        tilesFlat[y * mapSize.x + x] = tile;
    }

    public void ResetOutline()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (!tiles[i]) continue;
            tiles[i].DisableOutline();
        }
    }
    public List<BaseTile> Get8TilesAround(Vector2Int position)
    {
        int x = position.x;
        int y = position.y;

        List<BaseTile> tilesAround = new List<BaseTile> { };
        if (GetInitializedTile(x - 1, y)) tilesAround.Add(GetInitializedTile(x - 1, y));
        if (GetInitializedTile(x + 1, y)) tilesAround.Add(GetInitializedTile(x + 1, y));
        if (GetInitializedTile(x, y - 1)) tilesAround.Add(GetInitializedTile(x, y - 1));
        if (GetInitializedTile(x, y + 1)) tilesAround.Add(GetInitializedTile(x, y + 1));

        if (GetInitializedTile(x - 1, y - 1)) tilesAround.Add(GetInitializedTile(x - 1, y - 1));
        if (GetInitializedTile(x + 1, y - 1)) tilesAround.Add(GetInitializedTile(x + 1, y - 1));
        if (GetInitializedTile(x + 1, y + 1)) tilesAround.Add(GetInitializedTile(x + 1, y + 1));
        if (GetInitializedTile(x - 1, y + 1)) tilesAround.Add(GetInitializedTile(x - 1, y + 1));
        return tilesAround;
    }
    public List<BaseTile> Get4TilesAround(int x, int y)
    {
        List<BaseTile> tilesAround = new List<BaseTile> { };
        if (GetInitializedTile(x - 1, y)) tilesAround.Add(GetInitializedTile(x - 1, y));
        if (GetInitializedTile(x + 1, y)) tilesAround.Add(GetInitializedTile(x + 1, y));
        if (GetInitializedTile(x, y - 1)) tilesAround.Add(GetInitializedTile(x, y - 1));
        if (GetInitializedTile(x, y + 1)) tilesAround.Add(GetInitializedTile(x, y + 1));
        return tilesAround;
    }
    public List<BaseTile> Get4TilesAround(Vector2Int position)
    {
        List<BaseTile> tilesAround = new List<BaseTile> { };
        if (GetInitializedTile(position.x - 1, position.y)) tilesAround.Add(GetInitializedTile(position.x - 1, position.y));
        if (GetInitializedTile(position.x + 1, position.y)) tilesAround.Add(GetInitializedTile(position.x + 1, position.y));
        if (GetInitializedTile(position.x, position.y - 1)) tilesAround.Add(GetInitializedTile(position.x, position.y - 1));
        if (GetInitializedTile(position.x, position.y + 1)) tilesAround.Add(GetInitializedTile(position.x, position.y + 1));
        return tilesAround;
    }

    public void Initialize()
    {
        tiles = new BaseTile[tilesFlat.Length];

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                BaseTile baseTile = GetTile(x, y);
                if (baseTile == null) continue;

                GameObject tile = Instantiate(baseTile.gameObject, transform);

                BaseTile initializedTile = tile.GetComponent<BaseTile>();
                tiles[y * mapSize.x + x] = initializedTile;

                tile.transform.localPosition = new Vector3(x, 0, y) * tileSize;
                initializedTile.position = new Vector2Int(x, y);
                tile.name = $"{initializedTile.hierarchyName} at {x}:{y}";
            }
        }
    }
}
