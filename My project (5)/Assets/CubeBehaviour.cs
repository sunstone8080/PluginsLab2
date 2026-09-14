using UnityEngine;


//Behaviour attached to every cube
//size variable that is the object's scale transform.

public class CubeBehaviour : MonoBehaviour
{
    [Tooltip("Uniform scale applied to the cube. Kept in [0.1, 2] by the custom editor.")]
    public float size = 1f;

    private void OnValidate()
    {
        ApplyScale();
    }

    private void ApplyScale()
    {
        transform.localScale = Vector3.one * size;
    }
}