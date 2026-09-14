using UnityEngine;

//attatches to spheres and shows radius to scale

public class SphereBehaviour : MonoBehaviour
{
    [Tooltip("Radius of the sphere. Kept >= 1 by the custom editor.")]
    public float radius = 1f;

    private void OnValidate()
    {
        ApplyScale();
    }

    private void ApplyScale()
    {
        transform.localScale = Vector3.one * (radius * 2f);
    }
}