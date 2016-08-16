using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Trigger_Base {
    
    public string assetName;
    [HideInInspector] public int assetIndex;   //assigned by AssetsViewerAssetManagement.cs

    public Categories_Triggers categoryTriggers;
 
    public string assetUsageSet;
    public string assetDesc;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

    //triggers have no ingame texture


}
