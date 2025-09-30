using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGrid))]
public class MapGridInspectorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        MapGrid mapGrid = (MapGrid)target;

        DrawDefaultInspector();

        GUILayout.Space(25f);

        if (GUILayout.Button("Generate Grid"))
        {
            mapGrid.GenerateGrid();
        }
        GUILayout.Space(10f);
        if (GUILayout.Button("Clear Grid"))
        {
            mapGrid.ClearGrid();
        }
    }
}