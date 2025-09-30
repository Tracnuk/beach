using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGrid))]
public class MapGridInspectorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        MapGrid mapGrid = (MapGrid)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate Grid"))
        {
            mapGrid.GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            mapGrid.ClearGrid();
        }
    }
}