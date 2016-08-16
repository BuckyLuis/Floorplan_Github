﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Prop_Base {
    
    public string assetName;
    [HideInInspector] public int assetIndex;   //assigned by AssetsViewerAssetManagement.cs

    public Categories_Props categoryProps;
  
    public string assetUsageSet;
    public string assetDesc;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

    public int uvMapSectorFlag;
    public int meshsetFlag;
    [HideInInspector] public string meshsetString;
}
