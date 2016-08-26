using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Asset_Tileset_Base {

    public string assetName;
    [HideInInspector] public int assetIndex;   //assigned by AssetsViewerAssetManagement.cs
    public Categories_Tilesets categoryTilesets;
    [HideInInspector] public string assetMaterialName; 

    public Sprite assetEntryIcon_wall;
    public Sprite assetEntryIcon_corner;
    public Sprite assetEntryIcon_cornerInv;
    public Sprite assetEntryIcon_floor;

    public Color assetTilesetColor;
    [HideInInspector] public List<GameObject> tilesetMembers = new List<GameObject>();


    public GameObject wallPrefab;
    public GameObject cornerPrefab;
    public GameObject cornerInversePrefab;
    public GameObject floorPrefab;


    [HideInInspector] public Material assetMaterial;
    public int uvMapSectorFlag;
    public int meshsetFlag;
    [HideInInspector] public string meshsetString;
    public Sprite assetUsageIcon;               //used only in editor, convenience

}
