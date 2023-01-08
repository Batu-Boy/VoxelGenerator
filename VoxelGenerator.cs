using System.Linq;
using UnityEditor;
using UnityEngine;

public class VoxelGenerator : MonoBehaviour
{
    [Header("Voxel Settings")]
    public Texture2D sprite;
    public float scaleFactor = 1;

    [Header("References")]
    public GameObject pixelPrefab;

    private Material[] voxelMaterials;
    GameObject parent;

    public void GenerateVoxel()
    {
        UpdateMaterialList();
        Vector3 camPos = new(sprite.width * scaleFactor / 2, sprite.height * scaleFactor / 2, -50);
        Camera.main.transform.position = camPos;

        parent = new GameObject($"{sprite.name}_Voxel");

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

        if (pixelColor.a == 0)
        {
            return;
        }
        Vector3 position = new Vector3(x, y, 0) * scaleFactor;
        GameObject pixel = (GameObject)PrefabUtility.InstantiatePrefab(pixelPrefab, parent.transform);
        pixel.transform.localPosition = position;
        pixel.transform.localScale = Vector3.one * scaleFactor;
        var pixelRenderer = pixelPrefab.GetComponent<Renderer>();
        if (CheckMaterial(pixelColor, out var mat))
        {
            pixelRenderer.sharedMaterial = mat;
            return;
        }

        mat = new Material(Shader.Find("Unlit/Color"))
        {
            color = pixelColor,
            name = pixelColor.ToString()
        };
        
        pixelRenderer.sharedMaterial = mat;
        
        AssetDatabase.CreateAsset(mat, $"Assets/Resources/VoxelMaterials/{mat.name}.mat");
        AssetDatabase.SaveAssets();
        UpdateMaterialList();
    }

    private bool CheckMaterial(Color pixelColor, out Material mat)
    {
        foreach (Material voxelMaterial in voxelMaterials)
        {
            if (voxelMaterial.color == pixelColor)
            {
                mat = voxelMaterial;
                return true;
            }
        }
        mat = null;
        return false;
    }
    
    public void SaveVoxelAsPrefab()
    {
        string localPath = $"Assets/_VoxelGenerator/GeneratedVoxels/{parent.name}.prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        PrefabUtility.SaveAsPrefabAssetAndConnect(parent, localPath, InteractionMode.AutomatedAction);
        AssetDatabase.SaveAssets();
    }
    
    private void UpdateMaterialList()
    {
        voxelMaterials = Resources.LoadAll("VoxelMaterials", typeof(Material)).Cast<Material>().ToArray();
    }
}