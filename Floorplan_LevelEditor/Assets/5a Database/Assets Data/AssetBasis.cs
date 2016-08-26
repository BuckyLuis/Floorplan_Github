using UnityEngine;
using System.Collections;

[System.Serializable]
public class AssetBasis {
    
    public string assetName;
    [HideInInspector] public int assetIndex;   // index in AssetsDictionary -- used for ingame LevelConstruction        //assigned by AssetsViewerAssetManagement.cs 
    [HideInInspector] public string assetMaterialName;   //the material's name  -- used for LevelConstruction

    public Sprite assetEntryIcon;            //only in editor
    public GameObject worldObjectPrefab;       //reference of GameObject Mesh Prefab -- only in editor

    public int tilesetIndex; //only in editor - 0 = false   (index - 1) 
    public RoleInTileset tilesetRole;

    [HideInInspector] public Material assetMaterial;   //reference of Material Mesh Texture -- only in editor
    public int uvMapSectorFlag;                          //only in editor
    public int texturesetFlag;                              //only in editor
    [HideInInspector] public string texturesetString;       //only in editor
    public Sprite assetUsageIcon;               //used only in editor, convenience
}
