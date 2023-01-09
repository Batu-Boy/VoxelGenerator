using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class VoxelGenerator : MonoBehaviour
{
    [Header("Voxel Settings")]
    public Texture2D sprite;
    public float scaleFactor = 1;

    [Header("References")]
    public GameObject pixelPrefab;

    GameObject parent;
    private Material voxelMaterial;
    private string folderPath;
    
    public void GenerateVoxel()
    {
        Vector3 camPos = new(sprite.width * scaleFactor / 2, sprite.height * scaleFactor / 2, -50);
        Camera.main!.transform.position = camPos;

        parent = new GameObject($"{sprite.name}_Voxel");
        
        voxelMaterial = new Material(Shader.Find("Unlit/Texture"))
        {
            mainTexture = sprite,
            name = $"{sprite.name}VoxelMaterial"
        };

        for (int x = 0; x < sprite.width; x++)
        {
            for (int y = 0; y < sprite.height; y++)
            {
                GeneratePixel(x, y);
            }
        }
    }

    private void GeneratePixel(int x, int y)
    {
        Color pixelColor = sprite.GetPixel(x, y);

        if (pixelColor.a == 0) return;

        var pixel = (GameObject)PrefabUtility.InstantiatePrefab(pixelPrefab, parent.transform);
        
        var position = new Vector3(x, y, 0) * scaleFactor;
        pixel.transform.localPosition = position;
        pixel.transform.localScale = Vector3.one * scaleFactor;
        
        var pixelRenderer = pixel.GetComponent<Renderer>();
        pixelRenderer.sharedMaterial = voxelMaterial;
        
        var meshFilter = pixel.GetComponent<MeshFilter>();
        var tempMesh = Instantiate(meshFilter.sharedMesh);
        var uvs = new Vector2[tempMesh.vertices.Length];
        for (int i = 0; i < tempMesh.vertices.Length; i++)
        {
            uvs[i] = new Vector2(x / (float)sprite.width, y / (float)sprite.height);
        }
        tempMesh.uv = uvs;
        meshFilter.sharedMesh = tempMesh;
    }

    public void SaveVoxel()
    {
        if (AssetDatabase.IsValidFolder($"Assets/_VoxelGenerator/Voxels/{sprite.name}Voxel"))
        {
            Debug.LogWarning("Folder Already Exist Please Check Path: " + $"Assets/_VoxelGenerator/Voxels/{sprite.name}Voxel");
            return;
        }
        var guid = AssetDatabase.CreateFolder("Assets/_VoxelGenerator/Voxels", sprite.name + "Voxel");
        folderPath = AssetDatabase.GUIDToAssetPath(guid);
        AssetDatabase.CreateAsset(voxelMaterial, $"{folderPath}/{voxelMaterial.name}.mat");
        var localPath = $"{folderPath}/{parent.name}.prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(parent, localPath, InteractionMode.AutomatedAction);
        AssetDatabase.SaveAssets();
    }
}