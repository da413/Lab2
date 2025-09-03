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

        if (GUILayout.Button("Select all Spheres"))
        {
            var allSpheresScript = GameObject.FindObjectsOfType<Spheres>();
            var allSpheresGameObjects = allSpheresScript.Select(spheres => spheres.gameObject).ToArray();
            Selection.objects = allSpheresGameObjects;
        }
    }
}
