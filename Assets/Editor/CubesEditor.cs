using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(Cubes)), CanEditMultipleObjects]
public class CubesEditor : Editor
{
    private static bool cubesEnabled = true;
    private string buttonTitle = "Disable";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var size = serializedObject.FindProperty("size");
        EditorGUILayout.PropertyField(size);
        serializedObject.ApplyModifiedProperties();

        if (size.floatValue < 0)
        {
            EditorGUILayout.HelpBox("Size cannot be less than 0!", MessageType.Warning);
        }

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Select all Cubes"))
        {
            var allCubesScript = GameObject.FindObjectsOfType<Cubes>();
            var allCubesGameObjects = allCubesScript.Select(cubesComponent => cubesComponent.gameObject).ToArray();
            Selection.objects = allCubesGameObjects;
        }

        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = null;
        }
        
        EditorGUILayout.EndHorizontal();

        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = cubesEnabled ? Color.red : Color.green;
        buttonTitle = cubesEnabled ? "Disable" : "Enable";

        if (GUILayout.Button(buttonTitle + " all Cubes", GUILayout.Height(40)))
        {
            foreach (var cubes in GameObject.FindObjectsOfType<Cubes>(true))
            {
                cubes.gameObject.SetActive(!cubes.gameObject.activeSelf);
            }

            cubesEnabled = !cubesEnabled;
        }
        GUI.backgroundColor = cachedColor;
    }
}
