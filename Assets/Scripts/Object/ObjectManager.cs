using UnityEngine;
using UnityEngine.UIElements;

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

    public BaseObject GetInitializedObject(Vector2Int position)
    {
        return objects[position.y * mapSize.x + position.x];
    }

    public Vector3 GridToWorldPosition(int x, int y)
    {
        return transform.position+new Vector3((float)x * objectSize, 0, (float)y*objectSize);
    }
    public Vector3 GridToWorldPosition(Vector2Int position)
    {
        return transform.position + new Vector3((float)position.x * objectSize, 0, (float)position.y * objectSize);
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
