using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Trigger_Base {
    
    public string assetName;
    [HideInInspector] public int assetIndex;   //assigned by AssetsViewerAssetManagement.cs
    public Categories_Triggers categoryTriggers;
    [HideInInspector] public string assetMaterialName; 
 
    public string assetUsageSet;
    public string assetDesc;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

  
    [HideInInspector] public Material assetMaterial;   //triggers have no ingame texture .. but have an in-editor texture

/*    public int uvMapSectorFlag;
    public int meshsetFlag;
    [HideInInspector] public string meshsetString;*/
}
