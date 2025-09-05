using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(Spheres)), CanEditMultipleObjects]
public class SpheresEditor : Editor
{

    private static bool spheresEnabled = true;
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

        if (GUILayout.Button("Select all Spheres"))
        {
            var allSpheresScript = GameObject.FindObjectsOfType<Spheres>();
            var allSpheresGameObjects = allSpheresScript.Select(spheresComponent => spheresComponent.gameObject).ToArray();
            Selection.objects = allSpheresGameObjects;
        }

        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = null;
        }
        
        EditorGUILayout.EndHorizontal();

        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = spheresEnabled ? Color.red : Color.green;
        buttonTitle = spheresEnabled ? "Disable" : "Enable";

        if (GUILayout.Button(buttonTitle + " all Spheres", GUILayout.Height(40)))
        {
            foreach (var spheres in GameObject.FindObjectsOfType<Spheres>(true))
            {
                spheres.gameObject.SetActive(!spheres.gameObject.activeSelf);
            }

            spheresEnabled = !spheresEnabled;
        }
        GUI.backgroundColor = cachedColor;
    }
}
