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


    int assetIndexCounter;
//------------- Assets Lists --------------------
    [Header ("--- Asset Lists ---")]
    public List<Asset_Floor_Base> assetsList_Floors = new List<Asset_Floor_Base>();
    public List<Asset_Wall_Base> assetsList_Walls = new List<Asset_Wall_Base>();
    public List<Asset_Doodad_Base> assetsList_Doodads = new List<Asset_Doodad_Base>();
    public List<Asset_Prop_Base> assetsList_Props = new List<Asset_Prop_Base>();
    public List<Asset_Actor_Base> assetsList_Actors = new List<Asset_Actor_Base>();
    public List<Asset_Trigger_Base> assetsList_Triggers = new List<Asset_Trigger_Base>();


//----------- Assets Dicts ----------------------
    [Header (" --- Assets Dicts - DO NOT EDIT! --- ")]
    [Space(50)]
    public Dictionary_sGo assetsDict_Floors;
    public Dictionary_sGo assetsDict_Walls;
    public Dictionary_sGo assetsDict_Doodads;
    public Dictionary_sGo assetsDict_Props;
    public Dictionary_sGo assetsDict_Actors;
    public Dictionary_sGo assetsDict_Triggers;
   
//---------------- UI refs ----------------------
    [Header (" --- UI references - DO NOT EDIT! --- ")]
    [Space(50)]
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
        assetIndexCounter = 1;
        foreach (var floorEntry in assetsList_Floors) {
            floorEntry.assetIndex = assetIndexCounter;      //auto assign assetIndex
            assetIndexCounter++;

            tempEntry = Instantiate(floorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Floors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Floors>();
            tempScript.assetFloorsName = floorEntry.assetFloorsName;
            tempScript.assetIndex = floorEntry.assetIndex;
            tempScript.categoryFloors = floorEntry.categoryFloors;
            tempScript.assetEntryIcon = floorEntry.assetEntryIcon;
            tempScript.assetFloorsDesc = floorEntry.assetFloorsDesc;
            tempScript.assetTilesetColor = floorEntry.assetTilesetColor;
            tempScript.assetWorldObject = floorEntry.assetWorldObject;

            assetsDict_Floors.Add(string.Format("{0},{1}", (int)floorEntry.categoryFloors, floorEntry.assetIndex), tempEntry);
        }

        assetIndexCounter = 1;
        foreach (var wallEntry in assetsList_Walls) {
            wallEntry.assetIndex = assetIndexCounter;      //auto assign assetIndex
            assetIndexCounter++;

            tempEntry = Instantiate(wallEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Walls tempScript = tempEntry.GetComponent<AssetsViewerEntry_Walls>();
            tempScript.assetWallsName = wallEntry.assetWallsName;
            tempScript.assetIndex = wallEntry.assetIndex;
            tempScript.categoryWalls = wallEntry.categoryWalls;
            tempScript.assetEntryIcon = wallEntry.assetEntryIcon;
            tempScript.assetWallsDesc = wallEntry.assetWallsDesc;
            tempScript.assetTilesetColor = wallEntry.assetTilesetColor;
            tempScript.assetWorldObject = wallEntry.assetWorldObject;

            assetsDict_Walls.Add(string.Format("{0},{1}", (int)wallEntry.categoryWalls, wallEntry.assetIndex), tempEntry);
        }

        assetIndexCounter = 1;
        foreach (var doodadEntry in assetsList_Doodads) {
            doodadEntry.assetIndex = assetIndexCounter;      //auto assign assetIndex
            assetIndexCounter++;

            tempEntry = Instantiate(doodadEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Doodads tempScript = tempEntry.GetComponent<AssetsViewerEntry_Doodads>();
            tempScript.assetDoodadsName = doodadEntry.assetDoodadsName;
            tempScript.assetIndex = doodadEntry.assetIndex;
            tempScript.categoryDoodads = doodadEntry.categoryDoodads;
            tempScript.assetEntryIcon = doodadEntry.assetEntryIcon;
            tempScript.assetDoodadsDesc = doodadEntry.assetDoodadsDesc;
            tempScript.assetTilesetColor = doodadEntry.assetTilesetColor;
            tempScript.assetWorldObject = doodadEntry.assetWorldObject;

            assetsDict_Doodads.Add(string.Format("{0},{1}", (int)doodadEntry.categoryDoodads, doodadEntry.assetIndex), tempEntry);
        }

        assetIndexCounter = 1;
        foreach (var propEntry in assetsList_Props) {
            propEntry.assetIndex = assetIndexCounter;      //auto assign assetIndex
            assetIndexCounter++;

            tempEntry = Instantiate(propEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Props tempScript = tempEntry.GetComponent<AssetsViewerEntry_Props>();
            tempScript.assetPropsName = propEntry.assetPropsName;
            tempScript.assetIndex = propEntry.assetIndex;
            tempScript.categoryProps = propEntry.categoryProps;
            tempScript.assetEntryIcon = propEntry.assetEntryIcon;
            tempScript.assetPropsDesc = propEntry.assetPropsDesc;
            tempScript.assetTilesetColor = propEntry.assetTilesetColor;
            tempScript.assetWorldObject = propEntry.assetWorldObject;

            assetsDict_Props.Add(string.Format("{0},{1}", (int)propEntry.categoryProps, propEntry.assetIndex), tempEntry);
        }

        assetIndexCounter = 1;
        foreach (var actorEntry in assetsList_Actors) {
            actorEntry.assetIndex = assetIndexCounter;      //auto assign assetIndex
            assetIndexCounter++;

            tempEntry = Instantiate(actorEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Actors tempScript = tempEntry.GetComponent<AssetsViewerEntry_Actors>();
            tempScript.assetActorsName = actorEntry.assetActorsName;
            tempScript.assetIndex = actorEntry.assetIndex;
            tempScript.categoryActors = actorEntry.categoryActors;
            tempScript.assetEntryIcon = actorEntry.assetEntryIcon;
            tempScript.assetActorsDesc = actorEntry.assetActorsDesc;
            tempScript.assetTilesetColor = actorEntry.assetTilesetColor;
            tempScript.assetWorldObject = actorEntry.assetWorldObject;

            assetsDict_Actors.Add(string.Format("{0},{1}", (int)actorEntry.categoryActors, actorEntry.assetIndex), tempEntry);
        }

        assetIndexCounter = 1;
        foreach (var triggerEntry in assetsList_Triggers) {
            triggerEntry.assetIndex = assetIndexCounter;      //auto assign assetIndex
            assetIndexCounter++;

            tempEntry = Instantiate(triggerEntryPrefab);
            tempEntry.transform.SetParent(viewAreaFloors.transform, false);
            AssetsViewerEntry_Triggers tempScript = tempEntry.GetComponent<AssetsViewerEntry_Triggers>();
            tempScript.assetTriggersName = triggerEntry.assetTriggersName;
            tempScript.assetIndex = triggerEntry.assetIndex;
            tempScript.categoryTriggers = triggerEntry.categoryTriggers;
            tempScript.assetEntryIcon = triggerEntry.assetEntryIcon;
            tempScript.assetTriggersDesc = triggerEntry.assetTriggersDesc;
            tempScript.assetTilesetColor = triggerEntry.assetTilesetColor;
            tempScript.assetWorldObject = triggerEntry.assetWorldObject;

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
