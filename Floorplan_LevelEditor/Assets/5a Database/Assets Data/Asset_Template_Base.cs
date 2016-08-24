using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Template_Base {

    public string assetName;
    [HideInInspector] public int assetIndex;   //assigned by AssetsViewerAssetManagement.cs
    public Categories_Templates categoryTemplates;
    [HideInInspector] public string assetMaterialName; 

    public string assetUsageSet;
    public string assetDesc;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

    [HideInInspector] public Material assetMaterial;
    public int uvMapSectorFlag;
    public int meshsetFlag;
    [HideInInspector] public string meshsetString;
}
