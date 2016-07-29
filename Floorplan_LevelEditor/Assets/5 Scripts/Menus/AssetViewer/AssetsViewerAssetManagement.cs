using UnityEngine;
using System.Collections.Generic;
using System;


public enum Categories_Floors { STANDARD, PUZZLE, HAZARD, SPECIAL }
public enum Categories_Walls { STANDARD, DOORJAMB, HAZARD, SPECIAL }        //TODO: come up with proper, needed categories
public enum Categories_Doodads { STANDARD, DECAL, SIGNS, SPECIAL }
public enum Categories_Props { STANDARD, ITEM, HAZARD, SPECIAL }
public enum Categories_Actors { STANDARD, FRIENDLY, ENEMY, BOSS }
public enum Categories_Triggers { STANDARD, SPAWNER, HAZARD, SPECIAL }

[Serializable] public class Dictionary_sGo : SerializableDictionary<string, GameObject> { }

public class AssetsViewerAssetManagement : MonoBehaviour {


    int assetIndexCounterCat0;
    int assetIndexCounterCat1;
    int assetIndexCounterCat2;
    int assetIndexCounterCat3;
//------------- Assets Lists --------------------
    [Header ("--- Asset Lists ---", order = 0)]            //in the editor you setup references to all of the asset's assets 
    public List<Asset_Floor_Base> assetsList_Floors = new List<Asset_Floor_Base>();
    public List<Asset_Wall_Base> assetsList_Walls = new List<Asset_Wall_Base>();
    public List<Asset_Doodad_Base> assetsList_Doodads = new List<Asset_Doodad_Base>();
    public List<Asset_Prop_Base> assetsList_Props = new List<Asset_Prop_Base>();
    public List<Asset_Actor_Base> assetsList_Actors = new List<Asset_Actor_Base>();
    public List<Asset_Trigger_Base> assetsList_Triggers = new List<Asset_Trigger_Base>();
    [Space(40, order = 1)]
    [Header ("--- --- --- --- --- ---", order = 2)]    


//----------- Assets Dicts ----------------------
    [Space(200, order = 3)]
    [Header (" --- Assets Dicts - DO NOT EDIT! --- ", order = 4)]  // these Dictionaries hold references to the constructed AssetViewerEntry objects



    public Dictionary_sGo assetsDict_Floors;
    public Dictionary_sGo assetsDict_Walls;
    public Dictionary_sGo assetsDict_Doodads;
    public Dictionary_sGo assetsDict_Props;
    public Dictionary_sGo assetsDict_Actors;
    public Dictionary_sGo assetsDict_Triggers;
   
//---------------- UI refs ----------------------
    [Space(30, order = 5)]
    [Header (" --- UI references - DO NOT EDIT! --- ", order = 6)] 

 
    [SerializeField] GameObject viewAreaFloors;
    [SerializeField] GameObject viewAreaWalls;
    [SerializeField] GameObject viewAreaDoodads;
    [SerializeField] GameObject viewAreaProps;
    [SerializeField] GameObject viewAreaActors;
    [SerializeField] GameObject viewAreaTriggers;

    [SerializeField] GameObject floorEntryPrefab;
    [SerializeField] GameObject wallEntryPrefab;
    [SerializeField] GameObject doodadEntryPrefab;
    [SerializeField] GameObject propEntryPrefab;
    [SerializeField] GameObject actorEntryPrefab;
    [SerializeField] GameObject triggerEntryPrefab;

    GameObject tempEntry;


 #region PopulateViews
	void Start () {
        PopulateAssetViews();
	}

    void PopulateAssetViews() {
        
        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var floorEntry in assetsList_Floors) {
            switch ((int)floorEntry.categoryFloors)
            {
                case 0:
                    floorEntry.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    floorEntry.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    floorEntry.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    floorEntry.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(floorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Floors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Floors>();
            tempScript.categoryFloors = floorEntry.categoryFloors;
            tempScript.assetName = floorEntry.assetName;
            tempScript.assetUsageSet = floorEntry.assetUsageSet;
            tempScript.assetDesc = floorEntry.assetDesc;
            tempScript.assetIndex = floorEntry.assetIndex;
            tempScript.assetEntryIcon = floorEntry.assetEntryIcon;
            tempScript.assetTilesetColor = floorEntry.assetTilesetColor;
            tempScript.assetWorldObject = floorEntry.worldObjectPrefab;

            assetsDict_Floors.Add(string.Format("{0},{1}", (int)floorEntry.categoryFloors, floorEntry.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var wallEntry in assetsList_Walls) {
            switch ((int)wallEntry.categoryWalls)
            {
                case 0:
                    wallEntry.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    wallEntry.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    wallEntry.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    wallEntry.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(wallEntryPrefab);
            tempEntry.transform.SetParent(viewAreaWalls.transform, false);
            AssetsViewerEntry_Walls tempScript = tempEntry.GetComponent<AssetsViewerEntry_Walls>();
            tempScript.categoryWalls = wallEntry.categoryWalls;
            tempScript.assetName = wallEntry.assetName;
            tempScript.assetUsageSet = wallEntry.assetUsageSet;
            tempScript.assetDesc = wallEntry.assetDesc;
            tempScript.assetIndex = wallEntry.assetIndex;
            tempScript.assetEntryIcon = wallEntry.assetEntryIcon;
            tempScript.assetTilesetColor = wallEntry.assetTilesetColor;
            tempScript.assetWorldObject = wallEntry.worldObjectPrefab;

            assetsDict_Walls.Add(string.Format("{0},{1}", (int)wallEntry.categoryWalls, wallEntry.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var doodadEntry in assetsList_Doodads) {
            switch ((int)doodadEntry.categoryDoodads)
            {
                case 0:
                    doodadEntry.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    doodadEntry.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    doodadEntry.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    doodadEntry.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }
            tempEntry = Instantiate(doodadEntryPrefab);
            tempEntry.transform.SetParent(viewAreaDoodads.transform, false);
            AssetsViewerEntry_Doodads tempScript = tempEntry.GetComponent<AssetsViewerEntry_Doodads>();
            tempScript.categoryDoodads = doodadEntry.categoryDoodads;
            tempScript.assetName = doodadEntry.assetName;
            tempScript.assetUsageSet = doodadEntry.assetUsageSet;
            tempScript.assetDesc = doodadEntry.assetDesc;
            tempScript.assetIndex = doodadEntry.assetIndex;
            tempScript.assetEntryIcon = doodadEntry.assetEntryIcon;
            tempScript.assetTilesetColor = doodadEntry.assetTilesetColor;
            tempScript.assetWorldObject = doodadEntry.worldObjectPrefab;

            assetsDict_Doodads.Add(string.Format("{0},{1}", (int)doodadEntry.categoryDoodads, doodadEntry.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var propEntry in assetsList_Props) {
            switch ((int)propEntry.categoryProps)
            {
                case 0:
                    propEntry.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    propEntry.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    propEntry.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    propEntry.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(propEntryPrefab);
            tempEntry.transform.SetParent(viewAreaProps.transform, false);
            AssetsViewerEntry_Props tempScript = tempEntry.GetComponent<AssetsViewerEntry_Props>();
            tempScript.categoryProps = propEntry.categoryProps;
            tempScript.assetName = propEntry.assetName;
            tempScript.assetUsageSet = propEntry.assetUsageSet;
            tempScript.assetDesc = propEntry.assetDesc;
            tempScript.assetIndex = propEntry.assetIndex;
            tempScript.assetEntryIcon = propEntry.assetEntryIcon;
            tempScript.assetTilesetColor = propEntry.assetTilesetColor;
            tempScript.assetWorldObject = propEntry.worldObjectPrefab;

            assetsDict_Props.Add(string.Format("{0},{1}", (int)propEntry.categoryProps, propEntry.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var actorEntry in assetsList_Actors) {
            switch ((int)actorEntry.categoryActors)
            {
                case 0:
                    actorEntry.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    actorEntry.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    actorEntry.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    actorEntry.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(actorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaActors.transform, false);
            AssetsViewerEntry_Actors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Actors>();
            tempScript.categoryActors = actorEntry.categoryActors;
            tempScript.assetName = actorEntry.assetName;
            tempScript.assetUsageSet = actorEntry.assetUsageSet;
            tempScript.assetDesc = actorEntry.assetDesc;
            tempScript.assetIndex = actorEntry.assetIndex;
            tempScript.assetEntryIcon = actorEntry.assetEntryIcon;
            tempScript.assetTilesetColor = actorEntry.assetTilesetColor;
            tempScript.assetWorldObject = actorEntry.worldObjectPrefab;

            assetsDict_Actors.Add(string.Format("{0},{1}", (int)actorEntry.categoryActors, actorEntry.assetIndex), tempEntry);
        }

        assetIndexCounterCat0 = 1;
        assetIndexCounterCat1 = 1;
        assetIndexCounterCat2 = 1;
        assetIndexCounterCat3 = 1;
        foreach (var triggerEntry in assetsList_Triggers) {
            switch ((int)triggerEntry.categoryTriggers)
            {
                case 0:
                    triggerEntry.assetIndex = assetIndexCounterCat0;  
                    assetIndexCounterCat0++;
                    break;
                case 1:
                    triggerEntry.assetIndex = assetIndexCounterCat1;  
                    assetIndexCounterCat1++;
                    break;
                case 2:
                    triggerEntry.assetIndex = assetIndexCounterCat2;  
                    assetIndexCounterCat2++;
                    break;
                case 3:
                    triggerEntry.assetIndex = assetIndexCounterCat3;  
                    assetIndexCounterCat3++;
                    break;
            }

            tempEntry = Instantiate(triggerEntryPrefab);
            tempEntry.transform.SetParent(viewAreaTriggers.transform, false);
            AssetsViewerEntry_Triggers tempScript = tempEntry.GetComponent<AssetsViewerEntry_Triggers>();
            tempScript.categoryTriggers = triggerEntry.categoryTriggers;
            tempScript.assetName = triggerEntry.assetName;
            tempScript.assetUsageSet = triggerEntry.assetUsageSet;
            tempScript.assetDesc = triggerEntry.assetDesc;
            tempScript.assetIndex = triggerEntry.assetIndex;
            tempScript.assetEntryIcon = triggerEntry.assetEntryIcon;
            tempScript.assetTilesetColor = triggerEntry.assetTilesetColor;
            tempScript.assetWorldObject = triggerEntry.worldObjectPrefab;

            assetsDict_Triggers.Add(string.Format("{0},{1}", (int)triggerEntry.categoryTriggers, triggerEntry.assetIndex), tempEntry);
        }
            
    }
#endregion
	

    public void ShowCategory_Floors(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> floorEntry in assetsDict_Floors) {
            if(SplitDictKey_GetCategory(floorEntry) == categoryIndex) {
                floorEntry.Value.SetActive(true);
            }
            else {
                floorEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Walls(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> wallEntry in assetsDict_Walls) {
            if(SplitDictKey_GetCategory(wallEntry) == categoryIndex) {
                wallEntry.Value.SetActive(true);
            }
            else {
                wallEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Doodads(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> doodadEntry in assetsDict_Doodads) {
            if(SplitDictKey_GetCategory(doodadEntry) == categoryIndex) {
                doodadEntry.Value.SetActive(true);
            }
            else {
                doodadEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Props(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> propEntry in assetsDict_Props) {
            if(SplitDictKey_GetCategory(propEntry) == categoryIndex) {
                propEntry.Value.SetActive(true);
            }
            else {
                propEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Actors(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> actorEntry in assetsDict_Actors) {
            if(SplitDictKey_GetCategory(actorEntry) == categoryIndex) {
                actorEntry.Value.SetActive(true);
            }
            else {
                actorEntry.Value.SetActive(false);
            }
        }
    }

    public void ShowCategory_Triggers(int categoryIndex) {
        foreach (KeyValuePair<string, GameObject> triggerEntry in assetsDict_Triggers) {
            if(SplitDictKey_GetCategory(triggerEntry) == categoryIndex) {
                triggerEntry.Value.SetActive(true);
            }
            else {
                triggerEntry.Value.SetActive(false);
            }
        }
    }


    int SplitDictKey_GetCategory(KeyValuePair<string, GameObject> entryToSplit) {
        string[] tempStringArray = entryToSplit.Key.Split(',');
        int entryCategory = int.Parse(tempStringArray[0]);
        return entryCategory;
    }
        

}
