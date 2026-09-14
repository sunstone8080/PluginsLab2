using UnityEditor;
using UnityEngine;


//menu item that creates 5 cubes and 5 spheres, each with its behaviour component.

public static class SampleObjectCreator
{
    private const int objectCount = 5;

    [MenuItem("Tools/Create 5 Cubes and 5 Spheres")]
    public static void CreateSampleObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = $"Cube_{i}";
            cube.transform.position = new Vector3(i * 2f, 0f, 0f);
            cube.AddComponent<CubeBehaviour>();
            Undo.RegisterCreatedObjectUndo(cube, "Create Cube");
        }

        for (int i = 0; i < objectCount; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.name = $"Sphere_{i}";
            sphere.transform.position = new Vector3(i * 2f, 0f, 3f);
            sphere.AddComponent<SphereBehaviour>();
            Undo.RegisterCreatedObjectUndo(sphere, "Create Sphere");
        }

        Debug.Log("Created 5 cubes and 5 spheres with CubeBehaviour / SphereBehaviour components.");
    }
}