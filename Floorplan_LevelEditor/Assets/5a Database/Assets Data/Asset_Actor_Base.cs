using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Actor_Base {
    
    public string assetName;

    public Categories_Actors categoryActors;
  
    public string assetUsageSet;
    public string assetDesc;

    public int assetIndex;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

    public int uvMapSectorFlag;
}
