using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapManager))]
public class MapManagerEditor : Editor
{
    private MapManager map;

    private void OnEnable()
    {
        map = (MapManager)target;
        EnsureArraySize();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        map.tileSize = EditorGUILayout.FloatField("Tile Size", map.tileSize);

        Vector2Int newSize = EditorGUILayout.Vector2IntField("Map Size", map.mapSize);

        GUILayout.Space(15f);

        if (newSize != map.mapSize)
        {
            ResizeArray(newSize);
        }

        int fieldSize = 80;

        for (int y = 0; y < map.mapSize.y; y++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < map.mapSize.x; x++)
            {
                BaseTile tile = map.GetTile(x, y);
                BaseTile newTile = DrawTileField(tile, fieldSize);

                if (newTile != tile)
                {
                    Undo.RecordObject(map, "Set Tile");
                    map.SetTile(x, y, newTile);
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(15f);

        if (GUILayout.Button("Clear Grid"))
        {
            Undo.RecordObject(map, "Clear Grid");
            for (int y = 0; y < map.mapSize.y; y++)
                for (int x = 0; x < map.mapSize.x; x++)
                    map.SetTile(x, y, null);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(map);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private BaseTile DrawTileField(BaseTile tile, int size)
    {
        Rect rect = GUILayoutUtility.GetRect(size, size);

        if (tile != null)
        {
            Texture2D preview = AssetPreview.GetAssetPreview(tile.gameObject);
            if (preview == null)
                preview = AssetPreview.GetMiniThumbnail(tile.gameObject);

            if (preview != null)
            {
                GUI.DrawTexture(rect, preview, ScaleMode.ScaleToFit);
            }
        }

        return (BaseTile)EditorGUI.ObjectField(rect, tile, typeof(BaseTile), false);
    }

    private void EnsureArraySize()
    {
        int size = map.mapSize.x * map.mapSize.y;
        var so = new SerializedObject(map);
        var tilesProp = so.FindProperty("tilesFlat");
        if (tilesProp != null && tilesProp.arraySize != size)
        {
            tilesProp.arraySize = size;
            so.ApplyModifiedProperties();
        }
    }

    private void ResizeArray(Vector2Int newSize)
    {
        int newLength = newSize.x * newSize.y;
        BaseTile[] newArray = new BaseTile[newLength];

        int copyX = Mathf.Min(newSize.x, map.mapSize.x);
        int copyY = Mathf.Min(newSize.y, map.mapSize.y);

        for (int y = 0; y < copyY; y++)
        {
            for (int x = 0; x < copyX; x++)
            {
                newArray[y * newSize.x + x] = map.GetTile(x, y);
            }
        }

        Undo.RecordObject(map, "Resize Grid");
        map.mapSize = newSize;

        var so = new SerializedObject(map);
        var tilesProp = so.FindProperty("tilesFlat");
        tilesProp.arraySize = newLength;
        for (int i = 0; i < newLength; i++)
            tilesProp.GetArrayElementAtIndex(i).objectReferenceValue = newArray[i];
        so.ApplyModifiedProperties();
    }
}
