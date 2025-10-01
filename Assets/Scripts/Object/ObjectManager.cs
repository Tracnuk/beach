using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Vector2Int mapSize;
    public float objectSize = 2;

    [SerializeField] private BaseObject[] objectsFlat;
    public BaseObject[] objects;
    [HideInInspector] public static ObjectManager Instance { get; private set; }

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
    public BaseObject GetObject(int x, int y)
    {
        return objectsFlat[y * mapSize.x + x];
    }

    public BaseObject GetInitializedObject(int x, int y)
    {
        return objects[y * mapSize.x + x];
    }

    public void SetObject(int x, int y, BaseObject _object)
    {
        objectsFlat[y * mapSize.x + x] = _object;
    }
    public void Initialize()
    {
        objects = new BaseObject[objectsFlat.Length];

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                BaseObject baseObject = GetObject(x, y);
                if (baseObject == null) continue;

                GameObject _object = Instantiate(baseObject.gameObject, transform);

                BaseObject initializedBaseObject = _object.GetComponent<BaseObject>();
                objects[y * mapSize.x + x] = initializedBaseObject;

                _object.transform.localPosition = new Vector3(x, 0, y) * objectSize;
                initializedBaseObject.position = new Vector2Int(x, y);
                _object.name = $"{initializedBaseObject.hierarchyName} at {x}:{y}";

                if (MapManager.Instance.GetInitializedTile(x, y) != null)
                {
                    BaseTile tile = MapManager.Instance.GetInitializedTile(x, y);
                    initializedBaseObject.occupiedTile = tile;
                    tile.occupiedObject = initializedBaseObject;
                }
            }
        }
    }
}
