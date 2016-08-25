using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Prop_Base {
    
    public string assetName;
    [HideInInspector] public int assetIndex;   // index in AssetsDictionary -- used for ingame LevelConstruction        //assigned by AssetsViewerAssetManagement.cs 
    public Categories_Props categoryProps;   // assetCategory -- used for ingame LevelConstruction
    [HideInInspector] public string assetMaterialName;   //the material's name  -- used for LevelConstruction

    public Sprite assetEntryIcon;            //only in editor
    public Color assetTilesetColor;         //only in editor
    public GameObject worldObjectPrefab;       //reference of GameObject Mesh Prefab -- only in editor

    [HideInInspector] public Material assetMaterial;   //reference of Material Mesh Texture -- only in editor
    public int uvMapSectorFlag;                          //only in editor
    public int meshsetFlag;                              //only in editor
    [HideInInspector] public string meshsetString;       //only in editor*/
    public Sprite assetUsageIcon;               //used only in editor, convenience

}
