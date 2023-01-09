using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VoxelGeneratorEditorWindow : EditorWindow
{
    private VoxelGenerator voxelGenerator;
    private Texture2D sprite;
    private float scaleFactor = 1;
    private GameObject pixelPrefab;

    [MenuItem("Window/Voxel Generator")]
    public static void ShowWindow()
    {
        GetWindow<VoxelGeneratorEditorWindow>().Show();
    }

    private void OnGUI()
    {
        voxelGenerator = (VoxelGenerator)EditorGUILayout.ObjectField("Voxel Generator", voxelGenerator, typeof(VoxelGenerator), true);

        sprite = (Texture2D)EditorGUILayout.ObjectField("Sprite", sprite, typeof(Texture2D), false);
        scaleFactor = EditorGUILayout.FloatField("Scale Factor", scaleFactor);
        pixelPrefab = (GameObject)EditorGUILayout.ObjectField("Pixel Prefab", pixelPrefab, typeof(GameObject), false);

        if (GUILayout.Button("Generate Voxel"))
        {
            if (voxelGenerator != null && sprite != null && pixelPrefab != null)
            {
                voxelGenerator.sprite = sprite;
                voxelGenerator.scaleFactor = scaleFactor;
                voxelGenerator.pixelPrefab = pixelPrefab;
                voxelGenerator.GenerateVoxel();
            }
            else
            {
                Debug.LogWarning("Voxel Generator, Sprite, and Pixel Prefab must not be null");
            }
        }

        if (GUILayout.Button("Save Voxel"))
        {
            if (voxelGenerator != null)
            {
                voxelGenerator.SaveVoxel();
            }
            else
            {
                Debug.LogWarning("Voxel Generator must not be null");
            }
        }
    }
}
