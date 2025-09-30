using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Vector2Int mapSize;
    public float objectSize = 2;

    [SerializeField] private BaseObject[] objectsFlat;

    public BaseObject GetObject(int x, int y)
    {
        return objectsFlat[y * mapSize.x + x];
    }

    public void SetObject(int x, int y, BaseObject _object)
    {
        objectsFlat[y * mapSize.x + x] = _object;
    }

    private void Awake()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                BaseObject baseTile = GetObject(x, y);
                if (baseTile == null) continue;

                GameObject tile = Instantiate(baseTile.gameObject, transform);
                tile.transform.localPosition = new Vector3(x, 0, y) * objectSize;
                tile.GetComponent<BaseObject>().position = new Vector2Int(x, y);
                tile.GetComponent<BaseObject>().manager = this;
                tile.name = $"{x}:{y}";
            }
        }
    }
}
