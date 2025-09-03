using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(Spheres)), CanEditMultipleObjects]
public class SpheresEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Select all Spheres"))
        {
            var allSpheresScript = GameObject.FindObjectsOfType<Spheres>();
            var allSpheresGameObjects = allSpheresScript.Select(spheres => spheres.gameObject).ToArray();
            Selection.objects = allSpheresGameObjects;
        }
        if (GUILayout.Button("Clear Selection"))
        {
            Selection.objects = new Object[] { (target as Spheres).gameObject};
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Disable / Enable all Spheres", GUILayout.Height(40)))
        {
            foreach (var spheres in GameObject.FindObjectsOfType<Spheres>(true))
            {
                spheres.gameObject.SetActive(!spheres.gameObject.activeSelf);
            }
        }
    }
}
