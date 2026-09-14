using System.Linq;
using UnityEditor;
using UnityEngine;


//logic for CubeBehaviour and SphereBehaviour.
//Draws the default inspector, any type-specific warnings, Select al, Clear selection and Disable/Enable all.

public abstract class ShapeEditorBase<T> : Editor where T : Component
{
    protected abstract string SelectAllLabel { get; }
    protected abstract string ToggleAllLabel { get; }
    protected abstract void DrawWarnings();
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DrawWarnings();

        EditorGUILayout.Space();

        //select all and clear selection row
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button(SelectAllLabel))
            {
                Selection.objects = FindAllOfType()
                    .Select(component => component.gameObject)
                    .Cast<Object>()
                    .ToArray();
            }

            if (GUILayout.Button("Clear selection"))
            {
                Selection.objects = new Object[0];
            }
        }

        EditorGUILayout.Space();

        DrawToggleAllButton();
    }

    private void DrawToggleAllButton()
    {
        //gets all components
        T[] allComponents = FindAllOfType();
        bool anyEnabled = allComponents.Any(c => c.gameObject.activeSelf);

        Color cachedColor = GUI.backgroundColor;

        GUI.backgroundColor = anyEnabled ? Color.green : Color.red;

        if (GUILayout.Button(ToggleAllLabel, GUILayout.Height(40)))
        {
            //toggles what it found
            foreach (T component in allComponents)
            {
                GameObject go = component.gameObject;
                Undo.RecordObject(go, ToggleAllLabel);
                go.SetActive(!go.activeSelf);
            }
        }

        GUI.backgroundColor = cachedColor;
    }

    private static T[] FindAllOfType()
    {
#if UNITY_2023_1_OR_NEWER
        return Object.FindObjectsByType<T>(FindObjectsInactive.Include);
#else
        return Object.FindObjectsOfType<T>(true);
#endif
    }
}