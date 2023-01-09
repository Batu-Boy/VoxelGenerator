# VoxelGenerator
This script creates voxelized 3d version of given texture and saving object as prefab. Also Creates one material has given texture on it. Arrange pixel's UV's for getting correct color of texture pixel on material.

Set the sprite to voxelize

Configure scale factor

Assign a cube for pixels prefab

Once you call GenerateVoxel method, voxelized object will created in scene

Call SaveVoxel method for saving the created voxelized object in path: "Assets/_VoxelGenerator/Voxels/{parent.name}.prefab"

<img width="523" alt="Screen Shot 2023-01-08 at 18 00 10" src="https://user-images.githubusercontent.com/56830043/211203398-1b1215f6-9bb0-4dc0-82a7-5b8bcdf0e478.png">

!You need to import any editor button attibute for public methods (like OdinInspector or custom attributes) or you can use ui buttons in play mode.

<img width="1679" alt="Screen Shot 2023-01-08 at 18 02 05" src="https://user-images.githubusercontent.com/56830043/211203521-26ca6854-cb44-4151-af30-eadf59e39a4c.png">
