using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridBuilderEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        GridGenerator myScript = (GridGenerator)target;
        if (GUILayout.Button("Build Object")) {
            myScript.BuildGrid();
        }
    }
}

