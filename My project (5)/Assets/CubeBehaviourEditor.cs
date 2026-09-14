using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CubeBehaviour)), CanEditMultipleObjects]
public class CubeBehaviourEditor : ShapeEditorBase<CubeBehaviour>
{
    private const float maxSize = 2f;
    protected override string SelectAllLabel => "Select all cubes";
    protected override string ToggleAllLabel => "Disable/Enable all cubes";

    protected override void DrawWarnings()
    {
        foreach (Object obj in targets)
        {
            CubeBehaviour cube = (CubeBehaviour)obj;
            if (cube.size > maxSize)
            {
                EditorGUILayout.HelpBox("The cubes' size cannot be bigger than 2!", MessageType.Warning);
                break;
            }

            if (cube.size <= 0f)
            {
                EditorGUILayout.HelpBox("The cubes' size must be greater than 0!", MessageType.Error);
                break;
            }
        }
    }
}