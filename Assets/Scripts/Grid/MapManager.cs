using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Vector2Int mapSize;
    public float tileSize = 2;

    [SerializeField] private BaseTile[] tilesFlat;

    public BaseTile GetTile(int x, int y)
    {
        return tilesFlat[y * mapSize.x + x];
    }

    public void SetTile(int x, int y, BaseTile tile)
    {
        tilesFlat[y * mapSize.x + x] = tile;
    }

    private void Awake()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                BaseTile baseTile = GetTile(x, y);
                if (baseTile == null) continue;

                GameObject tile = Instantiate(baseTile.gameObject, transform);
                tile.transform.localPosition = new Vector3(x, 0, y) * tileSize;
                tile.GetComponent<BaseTile>().position = new Vector2Int(x, y);
                tile.GetComponent<BaseTile>().manager = this;
                tile.name = $"{x}:{y}";
            }
        }
    }
}
