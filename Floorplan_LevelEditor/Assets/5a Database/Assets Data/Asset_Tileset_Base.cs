using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Tileset_Base {

    public string assetName;
    [HideInInspector] public int assetIndex;   //assigned by AssetsViewerAssetManagement.cs
    public Categories_Tilesets categoryTilesets;
    [HideInInspector] public string assetMaterialName; 

    public Sprite assetEntryIcon_wall;
    public Sprite assetEntryIcon_corner;
    public Sprite assetEntryIcon_cornerInv;

    public Color assetTilesetColor;

    public GameObject wallPrefab;
    public GameObject cornerPrefab;
    public GameObject cornerInversePrefab;


    [HideInInspector] public Material assetMaterial;
    public int uvMapSectorFlag;
    public int meshsetFlag;
    [HideInInspector] public string meshsetString;
    public Sprite assetUsageIcon;               //used only in editor, convenience

}
