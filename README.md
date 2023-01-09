# VoxelGenerator
This script creates voxelized 3d version of given texture and saving object as prefab. Also Creates one material has given texture on it. Arrange pixel's UV's for getting correct color of texture pixel on material.


--SETUP--

In the beginning Create Folders on the path: "Assets/_VoxelGenerator/Voxels"

![Screen Shot 2023-01-09 at 12 12 20](https://user-images.githubusercontent.com/56830043/211273890-247daba0-df0c-42be-af53-e2883535ecc7.png)

First you need to assign VoxelGenerator to a GameObject on the Scene

![Screen Shot 2023-01-09 at 12 00 57](https://user-images.githubusercontent.com/56830043/211271972-809cf018-a3ee-4000-9497-8aa4358c682c.png)

Then open editor window Window -> Voxel Generator

![Screen Shot 2023-01-09 at 12 01 58](https://user-images.githubusercontent.com/56830043/211272140-89c41d3c-1c28-4589-88d5-1a32d22ee1f5.png)

Assign field VoxelGenerator Script on the scene on the EditorWindow's top

![Screen Shot 2023-01-09 at 12 03 24](https://user-images.githubusercontent.com/56830043/211272376-3ef90e0f-41cf-4e6c-96bf-ca843501aaeb.png)

Set the sprite to voxelize(Must Read/Write enabled)

Configure scale factor

Assign a cube for pixels prefab

Once you press Generate Voxel button, voxelized object will created in scene

![Screen Shot 2023-01-09 at 12 09 40](https://user-images.githubusercontent.com/56830043/211273461-d11b6b1d-6dbf-4d4a-9662-ce07e06b1e0f.png)

Hit SaveVoxel button for save the created voxelized object and material for it in path: "Assets/_VoxelGenerator/Voxels/${sprite.name}Voxel/"

![Screen Shot 2023-01-09 at 12 11 21](https://user-images.githubusercontent.com/56830043/211273720-2473ea06-99ff-46d6-a8d1-9648669bcbbb.png)

WOALA!
