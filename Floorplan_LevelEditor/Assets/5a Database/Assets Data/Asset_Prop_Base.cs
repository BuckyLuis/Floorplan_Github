using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Prop_Base {
    
    public string assetName;

    public Categories_Props categoryProps;
  
    public string assetUsageSet;
    public string assetDesc;

    public int assetIndex;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

}
