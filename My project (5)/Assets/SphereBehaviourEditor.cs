using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SphereBehaviour)), CanEditMultipleObjects]
public class SphereBehaviourEditor : ShapeEditorBase<SphereBehaviour>
{
    //creates select all, disable/enable, and the warning for radius size
    private const float minRadius = 1f;

    protected override string SelectAllLabel => "Select all spheres";
    protected override string ToggleAllLabel => "Disable/Enable all spheres";

    protected override void DrawWarnings()
    {
        foreach (Object obj in targets)
        {
            SphereBehaviour sphere = (SphereBehaviour)obj;
            if (sphere.radius < minRadius)
            {
                EditorGUILayout.HelpBox("The spheres' radius cannot be smaller than 1!", MessageType.Warning);
                break;
            }
        }
    }
}