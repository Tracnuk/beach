using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Vector2Int mapSize;
    public float tileSize = 2;

    [SerializeField] private BaseTile[] tilesFlat;
    public BaseTile[] tiles;

    [HideInInspector] public static MapManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
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

    public void SetTile(int x, int y, BaseTile tile)
    {
        tilesFlat[y * mapSize.x + x] = tile;
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
