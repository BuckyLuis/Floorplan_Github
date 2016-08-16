using UnityEngine;
using System.Collections;

[System.Serializable]
public class Asset_Wall_Base {

    public string assetName;

    public Categories_Walls categoryWalls;
   
    public string assetUsageSet;
    public string assetDesc;

    public int assetIndex;

    public Sprite assetEntryIcon;
    public Color assetTilesetColor;
    public GameObject worldObjectPrefab;

    public int uvMapSectorFlag;

}
