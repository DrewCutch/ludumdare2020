using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TravelPath))]
[CanEditMultipleObjects]
public class TravelPathEditor : Editor
{
    private int numPoints;

    public override void OnInspectorGUI()
    {
        TravelPath path = (TravelPath) target;
        base.OnInspectorGUI();

        GUILayout.Label("Generate Path");
        numPoints = EditorGUILayout.IntField(numPoints);


    }
}
